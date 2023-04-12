"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

let data = [];

connection.on("ReceiveMessage", function (user, message, sent) {
    console.log(`message sent at: ${new Date(sent).getTime()}`)
    const received = new Date();
    console.log(`new message recieved at: ${received.getTime()}`);
    data.push({
        Sent: sent,
        ClientReceived: received,
    });
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    const sent = new Date();
    console.log(`sending message at: ${sent.getTime()}`);
    connection.invoke("SendMessage", user, message, sent).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("printButton").addEventListener("click", function (event) {
    event.preventDefault();
    console.log(JSON.stringify(data, null, 4));
});