const express = require('express');
const app = express();
const http = require('http');
const path = require('path');
const server = http.createServer(app);
const { Server } = require("socket.io");
const io = new Server(server);
const fs = require('fs');

let data = [];

app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname, "public", "index.html"));
});

io.on('connection', (socket) => {
    socket.on('chat message', (msg, sent) => {
        console.log(new Date(sent).getTime());
        const ServerRecieved = new Date();
        console.log(`server forwarding message at: ${ServerRecieved.getTime()}`);
        data.push({
          Sent: sent,
          ServerRecieved
        });
      io.emit('chat message', msg, sent);
    });
});

app.get('/data', (req, res) => {
  fs.writeFile('./data.json', JSON.stringify(data, null, 4), err => {
    if (err) {
      console.error(err)
      return
    }
    //file written successfully
  })
});

server.listen(3000, () => {
  console.log('listening on *:3000');
});