const WebSocket = require('ws');

const wss = new WebSocket.Server({ port: 8080 });

function broadcast(message) {
    wss.clients.forEach(function each(client) {
        if (client.readyState === WebSocket.OPEN) {
            client.send(message);
        }
    });
}

let tick = 0;

setInterval(() => {
    const message = `[${tick++}] Специальное предложение! Скидки до 30% на все товары!`;
    broadcast(message);
}, 3000);

console.log('WebSocket server started on ws://localhost:8080');
