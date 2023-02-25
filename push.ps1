echo 'pushing and updating stack images'

echo 'cleaning dist folder'
rm -Recurse -Force ./bts-belelabestia-it
mkdir ./bts-belelabestia-it
echo 'dist folder clean'

echo 'copying assets'
cp ./docker-compose.yml ./bts-belelabestia-it
cp ./Caddyfile ./bts-belelabestia-it
cp ./after-push.sh ./bts-belelabestia-it
echo 'assets copied to dist folder'

echo 'exporting project image'
docker save beast-timesheet-app -o ./bts-belelabestia-it/beast-timesheet.image.tar
echo 'image exported'

echo 'pushing image (requires password)'
scp -rC ./bts-belelabestia-it root@belelabestia.it:./apps
echo 'image pushed on remote server'

echo 'running after-push script on remote server'
ssh root@belelabestia.it bash ./apps/bts-belelabestia-it/after-push.sh

echo 'stack update completed on remote server'