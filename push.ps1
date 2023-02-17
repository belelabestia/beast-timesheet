rm -Recurse -Force ./bts-belelabestia-it
mkdir ./bts-belelabestia-it
cp ./docker-compose.yml ./bts-belelabestia-it
cp ./Caddyfile ./bts-belelabestia-it
cp ./after-push.sh ./bts-belelabestia-it
docker save beast-timesheet-app -o ./bts-belelabestia-it/beast-timesheet.image.tar
scp -rC ./bts-belelabestia-it root@belelabestia.it:./apps
ssh root@belelabestia.it bash ./apps/bts-belelabestia-it/after-push.sh
