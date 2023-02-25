echo 'restarting stack with empty volume'

docker compose down
docker volume rm bts_db_volume
docker volume create bts_db_volume
docker compose up -d

echo 'volume reset completed and stack restarted'