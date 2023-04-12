# Proof of Concept Websockets

This project contains two folders, "SignalR" and "Socket.IO", which each contain a proof of concept implementation of a "hello world" chat application using different technologies. The purpose of this project is to compare the performance of these two technologies for the specific use case of a simple chat application.

## SignalR Folder

The "SignalR" folder contains a Visual Studio project written in C# that implements the "hello world" chat application using the SignalR library. This implementation was tested for performance by sending messages between clients and measuring the response times.

To run the SignalR implementation:
1. Open the SignalR project in Visual Studio.
2. Build and run the project.
3. Open the chat application in your web browser at http://localhost:5000.

## Socket.IO Folder

The "Socket.IO" folder contains a Node.js project written in JavaScript that implements the "hello world" chat application using the Socket.IO library and Express. This implementation was also tested for performance by sending messages between clients and measuring the response times.

To run the Socket.IO implementation:
1. Open a command prompt and navigate to the Socket.IO folder.
2. Run `npm install` to install the necessary dependencies.
3. Run `npm start` to start the server.
4. Open the chat application in your web browser at http://localhost:3000.

## Data.xlsx

The "Data.xlsx" file contains the collected data from both implementations, including response times from client to client and client to server, to calculate an average performance metric. 

