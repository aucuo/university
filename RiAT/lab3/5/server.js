const express = require('express');
const bodyParser = require('body-parser');
const jwt = require('jsonwebtoken');
const cors = require('cors');  // Добавьте эту строку
const app = express();
const port = 3000;

const secretKey = 'your_secret_key';
const users = { '1': '1' };  // Замените на реальные данные
app.use(cors());  // И эту строку

// Middleware для проверки токена
function verifyToken(req, res, next) {
    const token = req.headers['authorization'];

    if (!token) {
        return res.status(403).json({ message: 'No token provided.' });
    }

    jwt.verify(token, secretKey, (err, decoded) => {
        if (err) {
            return res.status(401).json({ message: 'Invalid token.' });
        }

        req.user = decoded;
        next();
    });
}

app.use(bodyParser.json());

// Роут для аутентификации
app.post('/login', (req, res) => {
    const { username, password } = req.body;

    if (users[username] && users[username] === password) {
        const token = jwt.sign({ username }, secretKey, { expiresIn: '1h' });
        res.json({ token });
    } else {
        res.status(401).json({ message: 'Invalid credentials.' });
    }
});

// Роут для получения изображений
app.get('/images', verifyToken, (req, res) => {
    var url = "https://api.thecatapi.com/v1/images/search?api_key=";
    var token = "live_WBjz9KlIZizjksUFGLqNsah1wqncpcc4cJ6PGRzt2aJOvFXsPasjgnPBeQJmlp0";

    fetch(url, {
        method: "GET",
        headers: {
            "Authorization": "Bearer " + token
        }
    })
        .then(response => response.json())
        .then(data => {
            res.json({ message: data });
        })
        .catch(error => {
            res.json({ message: 'Ошибка' });
        });
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});

// Обработчик ошибок для предотвращения возникновения ошибки node:events:491
app.on('error', (err) => {
    if (err.syscall !== 'listen') {
        throw err;
    }

    const bind = typeof port === 'string'
        ? 'Pipe ' + port
        : 'Port ' + port;

    // Обработка конфликта портов
    switch (err.code) {
        case 'EACCES':
            console.error(bind + ' requires elevated privileges');
            process.exit(1);
            break;
        case 'EADDRINUSE':
            console.error(bind + ' is already in use');
            process.exit(1);
            break;
        default:
            throw err;
    }
});
