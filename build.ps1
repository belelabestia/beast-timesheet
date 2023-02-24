echo 'cleaning stack'
docker compose down

echo 'rebuilding stack'
docker compose up -d --build

echo 'brand new stack running with external volume'
echo 'to reset volume, run ./db-reset.ps1'