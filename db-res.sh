echo 'cleaning db data'
rm -rf volume/*

echo 'restoring db data'
tar -xzf repo/db.bak volume

echo 'db restore completed'