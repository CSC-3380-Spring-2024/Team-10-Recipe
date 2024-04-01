#!/bin/bash

echo "RUNNING SERVER..."
# cd /Users/alexbrodsky/Desktop/Recipe_Proj/Team-10-Recipe || exit  ## not necessary
dotnet run &
# & is to run in the back so cammands can still be run

# Store the server process ID so we can easily terminate it later
SERVER_PID=$!
echo "SERVER PID: $SERVER_PID"

# Trap CTRL+C (SIGINT) and execute the 'kill' command for the server process
trap "echo 'STOPPING SERVER...'; kill $SERVER_PID; exit" SIGINT

sleep 5

echo "RUNNING CLIENT..."
cd ../Recipe_Proj || exit
dotnet run ## watch run is for hot reloading

# Instructions for manually stopping the server process
echo -e "\nSERVER PID IS: $SERVER_PID"
echo "To KILL the SERVER PROCESS:"
echo "1. CTRL+C to KILL the CLIENT."
echo "2. EXECUTE: kill $SERVER_PID"