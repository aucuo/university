const express = require('express');
const mysql = require('mysql2/promise');
const cors = require('cors');
const path = require('path');
const app = express();
const port = 3000;

app.use(cors());
app.use(express.json());
app.use('/images', express.static(path.join(__dirname, 'images')));

const pool = mysql.createPool({
    host: '127.0.0.2',
    user: 'root',
    password: '',
    database: 'cinego'
});

const getPagination = (page) => {
    const limit = 20;
    const offset = page ? (page - 1) * limit : 0;
    return { limit, offset };
};

const getMovies = async (req, res, query, params) => {
    try {
        const [movies] = await pool.query(query, params);
        res.status(200).json(movies);
    } catch (error) {
        console.error('Ошибка при получении фильмов:', error.message);
        res.status(500).send('Ошибка при получении фильмов');
    }
};

app.get('/genres', async (req, res) => {
    try {
        const [genres] = await pool.query('SELECT * FROM genres');
        res.status(200).json(genres);
    } catch (error) {
        console.error('Ошибка при получении жанров:', error.message);
        res.status(500).send('Ошибка при получении жанров');
    }
});

app.get('/movies/popular', async (req, res) => {
    const { limit, offset } = getPagination(parseInt(req.query.page));
    const query = 'SELECT * FROM movies ORDER BY `vote_average` DESC LIMIT ? OFFSET ?';
    await getMovies(req, res, query, [limit, offset]);
});

app.get('/movies/new', async (req, res) => {
    const { limit, offset } = getPagination(parseInt(req.query.page));
    const query = 'SELECT * FROM movies ORDER BY `release_date` DESC LIMIT ? OFFSET ?';
    await getMovies(req, res, query, [limit, offset]);
});

app.get('/movies', async (req, res) => {
    // Получение параметров пагинации
    const page = parseInt(req.query.page) || 1; // Значение по умолчанию для страницы - 1
    const { limit, offset } = getPagination(page);

    // Начальный запрос
    let query = 'SELECT * FROM movies ';
    const params = [];

    // Фильтрация по жанру
    if (req.query.with_genres) {
        query += 'JOIN moviegenres ON movies.id = moviegenres.movie_id WHERE moviegenres.genre_id = ? ';
        params.push(req.query.with_genres);
    }
    // Фильтрация по языку оригинала
    else if (req.query.with_original_language) {
        query += 'WHERE country = ? ';
        params.push(req.query.with_original_language === 'en' ? 'US' : 'RU');
    }
    // Поиск по названию или описанию
    else if (req.query.with_title) {
        query += 'WHERE title LIKE ? OR overview LIKE ? ';
        const title = `%${req.query.with_title}%`;
        params.push(title, title);
    }

    // Добавление пагинации к запросу
    query += 'LIMIT ? OFFSET ?';
    params.push(limit, offset);

    // Выполнение запроса и отправка результатов
    await getMovies(req, res, query, params);
});


app.get('/movie/:id', async (req, res) => {
    const movieId = parseInt(req.params.id);
    try {
        const [movie] = await pool.query('SELECT * FROM movies WHERE id = ?', [movieId]);
        const [genres] = await pool.query('SELECT genres.name FROM genres JOIN moviegenres ON genres.id = moviegenres.genre_id WHERE moviegenres.movie_id = ?', [movieId]);

        if (movie.length > 0) {
            res.status(200).json({ movie: movie[0], genres: genres.map(g => g.name) });
        } else {
            res.status(404).send('Фильм не найден');
        }
    } catch (error) {
        console.error('Ошибка при получении информации о фильме:', error.message);
        res.status(500).send('Ошибка при получении информации о фильме');
    }
});

app.get('/image/:imageName', (req, res) => {
    const imageName = req.params.imageName;
    const imagePath = path.join(__dirname, 'images', imageName);

    res.sendFile(imagePath, (err) => {
        if (err) {
            console.error('Ошибка при отправке изображения:', err.message);
            if (!res.headersSent) {
                res.status(404).send('Изображение не найдено');
            }
        }
    });
});

app.listen(port, () => {
    console.log(`Сервер запущен на http://localhost:${port}`);
});
