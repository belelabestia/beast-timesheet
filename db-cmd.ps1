if ($args[0] -eq 'bak')
{
    $beforeScriptMessage = 'exporting db data'
    $script = 'repo/db-bak.sh'
    $afterScriptMessage = 'db backup completed'
}
elseif ($args[0] -eq 'res')
{
    $beforeScriptMessage = 'restoring db data'
    $script = 'repo/db-res.sh'
    $afterScriptMessage = 'db restore completed'
}
else
{
    echo 'usage: ./db-cmd.ps1 <bak (backup) | res (restore)>'
    exit
}

echo 'stopping stack'
docker compose stop

echo $beforeScriptMessage

docker run --rm `
  -v ${pwd}:/repo `
  -v bts_db_volume:/volume `
  ubuntu bash $script

echo 'restarting stack'
docker compose start

echo $afterScriptMessage