cd ./BeastTimesheet
dotnet clean
dotnet build
cd ..

docker compose up -d --build
