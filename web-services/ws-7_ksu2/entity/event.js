import mongoose from 'mongoose';

const eventSchema = new mongoose.Schema({
  type: String,
  aggregateId: String,
  aggregateType: String,
  payload: Object,
});

const Event = mongoose.model('event', eventSchema);

export const EVENT_TYPES = {
  TASK_CREATED: 'CREATE_TASK',
  TASK_UPDATED: 'UPDATE_TASK',
  TASK_DELETED: 'DELETE_TASK',
  GET_ALL_TASKS: 'GET_ALL_TASKS',
  GET_TASK: 'GET_TASK',
};

export default Event;
