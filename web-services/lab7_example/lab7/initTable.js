const { Pool } = require('pg');

const pool = new Pool({
    connectionString: 'postgres://root:return2015@localhost:5432/example6',
});

pool.query(`
  CREATE TABLE IF NOT EXISTS events (
    event_id SERIAL PRIMARY KEY,
    aggregate_id UUID NOT NULL,
    aggregate_type VARCHAR(255) NOT NULL,
    event_type VARCHAR(255) NOT NULL,
    payload JSONB,
    created_at TIMESTAMPTZ DEFAULT NOW()
  );
`).then(() => {
    console.log('Event store table created');
}).catch((error) => {
    console.error('Error creating event store table', error);
});

pool.query(`
  CREATE TABLE IF NOT EXISTS snapshots (
    aggregate_id UUID PRIMARY KEY,
    aggregate_type VARCHAR(255) NOT NULL,
    data JSONB,
    created_at TIMESTAMPTZ DEFAULT NOW()
  );
`).then(() => {
    console.log('Snapshot table created');
}).catch((error) => {
    console.error('Error creating snapshot table', error);
});