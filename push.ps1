rm -Recurse -Force ./bts-belelabestia-it
mkdir ./bts-belelabestia-it
cp ./docker-compose.yml ./bts-belelabestia-it
cp ./Caddyfile ./bts-belelabestia-it
docker save beast-timesheet-app -o ./bts-belelabestia-it/beast-timesheet.image.tar
scp -rC ./bts-belelabestia-it root@belelabestia.it:./apps
ssh root@belelabestia.it docker load -i ./apps/bts-belelabestia-it/beast-timesheet.image.tar
ssh root@belelabestia.it docker compose -f ./apps/bts-belelabestia-it/docker-compose.yml up -d --force-recreate
ssh root@belelabestia.it docker system prune
ssh root@belelabestia.it caddy reload