echo 'resetting migrations'
cd .\BeastTimesheet\Server\


try
{
    echo 'deleting migrations folder'
    rm -Force -Recurse -ErrorAction Stop Migrations
    echo 'migrations folder deleted'
}
catch
{
    echo 'no folder to delete; skipping'
}


echo 'creating brand new StartOver migration'
dotnet ef migrations add StartOver
echo 'new migration created'

cd ../..
echo 'migrations reset completed'