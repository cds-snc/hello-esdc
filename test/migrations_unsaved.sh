#!/bin/bash

#-----
# RUN INSTRUCTIONS
# Run from the repo's base directory
# Example: sh util/migrations_unsaved.sh
#-----

# Build migrations
sh util/build_migrations.sh &> /dev/null
if [ "$?" != 0 ]
then
    printf "Could not build migrations file"
    exit 1
fi

# If migrations are out-of-date, this makes $? a non-zero value
git diff-index --quiet HEAD database/seed.sql 
if [ "$?" != 0 ]
then
    printf "Migrations file is out-of-date"
    exit 1
else
    printf "Migrations are up-to-date"
    exit 0
fi