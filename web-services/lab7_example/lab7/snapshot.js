class Snapshot {
    constructor({ aggregateId, aggregateType, data }) {
        this.aggregateId = aggregateId;
        this.aggregateType = aggregateType;
        this.data = data;
    }

    getData() {
        return this.data;
    }

    apply(event) {
        this.data = event.payload;
    }
}

module.exports = Snapshot; 