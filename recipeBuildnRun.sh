#!/bin/bash

echo "BUILDING THE SOLUTION..."
cd /Users/alexbrodsky/Desktop/Recipe_Proj/Team-10-Recipe || exit
dotnet build

echo "RUNNING SERVER..."
cd Recipe_Proj.Server || exit
dotnet run &
# & is to run in the back so cammands can still be run

# Store the server process ID so we can easily terminate it later
SERVER_PID=$!

sleep 5

echo "RUNNING CLIENT..."
cd ../Recipe_Proj || exit
dotnet run

# Instructions for manually stopping the server process
echo -e "\nSERVER PID STORED IN: \$SERVER_PID"
echo "To KILL the SERVER PROCESS:"
echo "1. CTRL+C to KILL the CLIENT."
echo "2. EXECUTE: kill $SERVER_PID or:"
echo -e "kill \$SERVER_PID"