CREATE USER replicator WITH REPLICATION ENCRYPTED PASSWORD 'replicator_motoca';
SELECT pg_create_physical_replication_slot('replication_slot');
