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
      switch (event.eventType) {
          case 'createClient':
              this.data = event.payload;
              break;
          case 'updateClient':
              this.data = { ...this.data, ...event.payload }
              break;
      }
  }
}

module.exports = Snapshot; 