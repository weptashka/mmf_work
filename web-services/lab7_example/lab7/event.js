class Event {
    constructor({ aggregateId, aggregateType, eventType, payload }) {
        this.aggregateId = aggregateId;
        this.aggregateType = aggregateType;
        this.eventType = eventType;
        this.payload = payload;
    }
}

module.exports = Event;

 