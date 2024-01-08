import express from 'express';
import mongoose from 'mongoose';

import { EVENT_TYPES } from '../entity/event.js';
import Snapshot from '../entity/snapshot.js';
import emitter from '../emitter.js';

const router = express.Router();

router.post('/', function (req, res, next) {
  const eventPayload = {
    aggregateId: new mongoose.Types.ObjectId(),
    // aggregateId: _id,
    aggregateType: 'task',
    data: {
      _id: new mongoose.Types.ObjectId(),
      title: req.body.title,
      description: req.body.description,
      status: req.body.status,
      priority: req.body.priority,
    },
  };

  emitter.emit(EVENT_TYPES.TASK_CREATED, eventPayload, res);
});

router.put('/:id', async function (req, res, next) {
  const eventPayload = {
    aggregateId: req.params.id,
    aggregateType: 'task',
    data: {
      _id: req.params.id,
      title: req.body.title,
      description: req.body.description,
      status: req.body.status,
      priority: req.body.priority,
    }
  };

  emitter.emit(EVENT_TYPES.TASK_UPDATED, eventPayload, res);
});

router.get('/:id', async function (req, res, next) {
  const snapshot = await Snapshot.findOne({
    aggregateId: req.params.id,
  });

  const eventPayload = {
    aggregateId: req.params.id,
    aggregateType: 'task',
    data: {
      _id: req.params.id,
      ...snapshot.data,
    }
  }

  emitter.emit(EVENT_TYPES.GET_TASK, eventPayload, res);
});

router.get('/', async function (req, res, next) {
  const snapshots = await Snapshot.find({ aggregateType: 'task' });

  const data = snapshots.map((snapshot) => ({
    id: snapshot.aggregateId,
    ...snapshot.data,
  }));

  const payload = { aggregateType: 'task', data };

  emitter.emit(EVENT_TYPES.GET_ALL_TASKS, payload, res);
});

export default router;
