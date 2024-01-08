import emitter from '../emitter.js';
import { EVENT_TYPES } from '../entity/event.js';
import Task from '../entity/task.js';
import Snapshot from '../entity/snapshot.js';
import pick from 'lodash/pick.js';

emitter.on(EVENT_TYPES.TASK_CREATED, (data, res) => {
  const task = new Task(data);

  const snapshot = new Snapshot({
    aggregateId: task._id,
    aggregateType: 'task',
    version: 1,
    data: pick(task, ['title', 'description', 'status', 'priority']),
  });

  task.save();
  snapshot.save();

  res.json(task);
});

emitter.on(EVENT_TYPES.TASK_UPDATED, (data, res) => {
  (async () => {
    const existedSnapshot = await Snapshot.findOne({
      aggregateId: data._id,
    });

    const snapshotData = {
      ...existedSnapshot.data,
      ...(data.title && { title: data.title }),
      ...(data.description && { description: data.description }),
      ...(data.status && { status: data.status }),
      ...(data.priority && { priority: data.priority }),
    };

    await Snapshot.findByIdAndUpdate(existedSnapshot._id, {
      version: existedSnapshot.version + 1,
      data: snapshotData,
    });
  })();

  Task.findByIdAndUpdate(data._id, {
    ...(data.title && { title: data.title }),
    ...(data.description && { description: data.description }),
    ...(data.status && { status: data.status }),
    ...(data.priority && { priority: data.priority }),
  }, {
    new: true,
  })
    .then((task) => {
      res.json(task);
    });
});

emitter.on(EVENT_TYPES.GET_ALL_TASKS, (data, res) => {
  res.json(data);
});

emitter.on(EVENT_TYPES.GET_TASK, (data, res) => {
  res.json(data);
});
