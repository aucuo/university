function showError(text) {
    const error = $('.error');

    if (text === undefined) {
        error.hide();
        return;
    }

    const errorText = error.find('.error__text')
    errorText.text(text);

    error.show();

}

async function getData() {
    try {
        const response = await $.ajax({
            url: 'https://localhost:7145/Clients',
            method: 'GET',
            contentType: 'application/json'
        });

        updateTable(response);
    } catch (error) {
        console.error('Ошибка при получении данных:', error);
        showError('Ошибка при получении данных (см.консоль)');
    }
}

async function getQuery(query) {
    try {
        const response = await $.ajax({
            url: 'https://localhost:7145/Query',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ query: query })
        });

        updateTable(response);
    } catch (error) {
        console.error('Ошибка при выполнении запроса:', error);
        showError('Ошибка при выполнении запроса (см.консоль)');
    }
}

function updateTable(data) {
    const $table = $('.result__table');
    const $thead = $table.find('thead tr');
    const $tbody = $table.find('tbody');

    // Очищаем текущие строки таблицы и заголовки
    $thead.empty();
    $tbody.empty();

    showError();

    // Проверяем, что данные не пусты
    if (data.length > 0) {
        // Используем ключи первого объекта в массиве для создания заголовков таблицы
        Object.keys(data[0]).forEach(key => {
            $('<th>').text(key).appendTo($thead);
        });

        // Заполняем строки таблицы данными
        data.forEach((item) => {
            const $row = $('<tr>').appendTo($tbody);
            Object.values(item).forEach(value => {
                $('<td>').text(value !== null ? value : 'Не указано').appendTo($row);
            });
        });
    } else {
        // Если данные пусты, выводим сообщение
        const $row = $('<tr>').appendTo($tbody);
        $('<td>').text('Данные не найдены').attr('colspan', Object.keys(data[0]).length).appendTo($row);
    }
}

function queryInsert(e) {
    // Получаем jQuery объект, представляющий ближайший родительский элемент с классом .latest__query
    const root = $(e.target).closest('.latest__query');

    // Используем метод .text() для получения текста из элемента с классом .latest__text
    const text = root.find('.latest__text').text().trim();
    showError();

    // Устанавливаем полученный текст в textarea с id #textarea
    $('#textarea').val(text);
}

$(document).ready(function() {
    getData();

    $('.form').submit(async function(event) {
        event.preventDefault();
        const query = $('#textarea').val().trim();

        $(this).trigger("reset");

        if (query === "") {
            await getData();
        } else {
            await getQuery(query);
        }
    });
});

$('.result__table tbody').on('click', 'tr', function() {
    const clientId = $(this).find('td:first').text(); // Получаем clientID из первой ячейки строки
    const queryText = `SELECT * FROM clients WHERE clientID = ${clientId}`;
    $('#textarea').val(queryText); // Вставляем текст запроса в textarea
});