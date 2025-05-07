#!/bin/bash
# wait-for.sh

echo "Aspetto che Postgres sia disponibile su $DB_HOST:$DB_PORT..."

until pg_isready -h "$DB_HOST" -p "$DB_PORT"; do
  echo "Postgres non ancora disponibile - attendo..."
  sleep 2
done

echo "Postgres è attivo, lancio l'app..."
exec dotnet WebionLibraryAPI.dll
