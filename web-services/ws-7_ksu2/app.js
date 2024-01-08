import express from 'express';
import cookieParser from 'cookie-parser';
import logger from 'morgan';

import indexRouter from './routes/index.js';
import tasksRouter from './routes/tasks.js';
import eventsRouter from './routes/events.js';
import snapshotsRouter from './routes/snapshots.js';

import './db.js';
import './handlers/task.handlers.js';

const app = express();

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());

app.use('/', indexRouter);
app.use('/tasks', tasksRouter);
app.use('/snapshots', snapshotsRouter);
app.use('/events', eventsRouter);

export default app;
