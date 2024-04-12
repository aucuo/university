// app.js
document.addEventListener('DOMContentLoaded', function () {
    const catImagesContainer = document.getElementById('catImages');

    // Функция для выполнения запроса на аутентификацию
    function login() {
        const username = prompt('Enter your username:');
        const password = prompt('Enter your password:');

        // Замените 'YOUR_BACKEND_URL' на адрес вашего бэкенда
        fetch('http://localhost:3000/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, password }),
        })
            .then(response => response.json())
            .then(data => {
                if (data.token) {
                    localStorage.setItem('token', data.token);
                    loadCatImages();
                } else {
                    alert('Invalid credentials.');
                }
            })
            .catch(error => {
                console.error('Error during login:', error);
            });
    }

    // Функция для загрузки фотографий котов
    function loadCatImages() {
        const token = localStorage.getItem('token');

        // Замените 'YOUR_BACKEND_URL' на адрес вашего бэкенда
        fetch('http://localhost:3000/images', {
            headers: {
                'Authorization': token,
            },
        })
            .then(response => response.json())
            .then(data => {
                // Обработка данных о фотографиях котов
                console.log(data);
            })
            .catch(error => {
                console.error('Error loading cat images:', error);
            });
    }
});
