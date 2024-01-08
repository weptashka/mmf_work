import express from 'express';
import pick from 'lodash/pick.js';
import merge from 'lodash/merge.js';

import Task from '../entity/task.js';
import Event, { EVENT_TYPES } from '../entity/event.js';
import Snapshot from '../entity/snapshot.js';

const router = express.Router();

router.get('/', async function (req, res, next) {
  const snapshots = await Snapshot.find({ aggregateType: 'task' });

  return res.json(snapshots);
});

router.get('/:id', async function (req, res, next) {
  const snapshots = await Event.find({
    aggregateId: req.params.id,
    aggregateType: 'task',
  });


  return res.json(snapshots);
});

export default router;
