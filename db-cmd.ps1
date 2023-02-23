if ($args[0] -eq 'bak')
{
    echo 'back up!'
    $script = 'repo/db-bak.sh'
}
elseif ($args[0] -eq 'res')
{
    echo 'restore!'
    $script = 'repo/db-res.sh'
}
else
{
    echo 'provide bak (backup) or res (restore)'
    exit
}

docker compose stop
docker run --rm `
  -v ${pwd}:/repo `
  -v bts_db_volume:/volume `
  ubuntu bash $script
docker compose start