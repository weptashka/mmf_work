import mongoose from 'mongoose';

const snapshotSchema = new mongoose.Schema({
  aggregateId: String,
  aggregateType: String,
  version: Number,
  data: Object,
});

const Snapshot = mongoose.model('snapshot', snapshotSchema);

export default Snapshot;
