import { EventEmitter } from 'events';
import Event from './entity/event.js';
import pick from 'lodash/pick.js';

class Emitter extends EventEmitter {
  emit(eventName, payload, res) {
    const eventPayload = Array.isArray(payload.data)
      ? payload.data
      : pick(payload.data, ['title', 'description', 'status', 'priority']);

    const event = new Event({
      type: eventName,
      aggregateId: payload.aggregateId,
      aggregateType: payload.aggregateType,
      payload: eventPayload,
    });

    event.save();
    super.emit(eventName, payload.data, res);
  }
}

export default new Emitter();
