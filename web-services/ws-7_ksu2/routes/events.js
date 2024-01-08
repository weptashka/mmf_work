import express from 'express';

import Event from '../entity/event.js';

const router = express.Router();

router.get('/', async function (req, res, next) {
  const events = await Event.find({ aggregateType: 'task' });

  return res.json(events);
});

router.get('/:id', async function (req, res, next) {
  const events = await Event.find({
    aggregateId: req.params.id,
    aggregateType: 'task',
  });

  return res.json(events);
});

export default router;
