import mongoose from 'mongoose';

const taskSchema = new mongoose.Schema({
  title: String,
  description: String,
  status: String,
  priority: String,
});

const Task = mongoose.model('task', taskSchema);

export default Task;
