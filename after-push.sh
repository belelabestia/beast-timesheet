echo 'after-push procedure activated'

echo 'loading updated image'
cd ./apps/bts-belelabestia-it
docker load -i ./beast-timesheet.image.tar
echo 'image updated'

echo 'rebooting stack'
docker compose down
docker compose up -d
echo 'new stack running'

echo 'cleaning system'
docker system prune -f
echo 'system clean'

echo 'reloading caddy'
caddy reload
echo 'caddy reloaded'

echo 'after-push sequence completed'