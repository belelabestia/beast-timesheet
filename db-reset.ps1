docker compose stop
docker volume rm bts_db_volume
docker volume create bts_db_volume
docker compose start