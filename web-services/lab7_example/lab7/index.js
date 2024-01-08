const express = require('express');
const { v4: uuidv4 } = require('uuid');
const { Pool } = require('pg');
const Event = require('./event');
const Snapshot = require('./snapshot');

const pool = new Pool({
    connectionString: 'postgres://root:return2015@localhost:5432/example6',
});

const app = express();
app.use(express.json());


app.post('/events', async (req, res) => {
    try {
        const { aggregateType, eventType, payload } = req.body;
        const aggregateId = uuidv4();

        // Creating new events (Event)
        const event = new Event({ aggregateId, aggregateType, eventType, payload });

        // Request the latest Snapshot for a given aggregateId
        const snapshotResult = await pool.query(`
      SELECT *
      FROM snapshots
      WHERE aggregate_id = $1
      ORDER BY created_at DESC
      LIMIT 1
    `, [event.aggregateId]);

        let snapshotData = null;
        if (snapshotResult.rowCount > 0) {
            snapshotData = snapshotResult.rows[0].data;
        }

        // Apply the event to the last Snapshot or create a new one if there is no Snapshot
        const snapshot = new Snapshot({ aggregateId: event.aggregateId, aggregateType: event.aggregateType, data: snapshotData });
        snapshot.apply(event);

        // Saving the event and Snapshot in the database
        const client = await pool.connect();
        try {
            await client.query('BEGIN');

            await client.query(`
        INSERT INTO events (aggregate_id, aggregate_type, event_type, payload)
        VALUES ($1, $2, $3, $4)
      `, [event.aggregateId, event.aggregateType, event.eventType, event.payload]);

            await client.query(`
        INSERT INTO snapshots (aggregate_id, aggregate_type, data)
        VALUES ($1, $2, $3)
        ON CONFLICT (aggregate_id) DO UPDATE SET
          data = EXCLUDED.data,
          created_at = NOW()
      `, [event.aggregateId, event.aggregateType, JSON.stringify(snapshot.getData())]);

            await client.query('COMMIT');
        } catch (error) {
            await client.query('ROLLBACK');
            throw error;
        } finally {
            client.release();
        }

        res.status(201).json({ message: 'Event created' });
    } catch (error) {
        console.error('Error creating event', error);
        res.status(500).json({ error: 'Internal Server Error' });
    }
});

app.get('/events/:aggregateId', async (req, res) => {
    try {
        const { aggregateId } = req.params;

        // Get all events for a given aggregateId
        const result = await pool.query(`
      SELECT *
      FROM events
      WHERE aggregate_id = $1
      ORDER BY event_id ASC
    `, [aggregateId]);

        const events = result.rows.map((row) => ({
            aggregateId: row.aggregate_id,
            aggregateType: row.aggregate_type,
            eventType: row.event_type,
            payload: row.payload,
        }));

        res.json(events);
    } catch (error) {
        console.error('Error retrieving events', error);
        res.status(500).json({ error: 'Internal Server Error' });
    }
});

app.get('/snapshot/:aggregateId', async (req, res) => {
    try {
        const { aggregateId } = req.params;

        // Get the latest Snapshot for a given aggregateId
        const result = await pool.query(`
      SELECT *
      FROM snapshots
      WHERE aggregate_id = $1
      ORDER BY created_at DESC
      LIMIT 1
    `, [aggregateId]);

        if (result.rowCount > 0) {
            const snapshot = result.rows[0];
            res.json({
                aggregateId: snapshot.aggregate_id,
                aggregateType: snapshot.aggregate_type,
                data: snapshot.data,
            });
        } else {
            res.json(null);
        }
    } catch (error) {
        console.error('Error retrieving snapshot', error);
        res.status(500).json({ error: 'Internal Server Error' });
    }
});

app.listen(3000, () => {
    console.log('app running on port 3000');
});