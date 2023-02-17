cd ./apps/bts-belelabestia-it
docker load -i ./beast-timesheet.image.tar
docker compose down
docker compose up -d
docker system prune -f
caddy reload