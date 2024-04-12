import pika
from pika.exceptions import AMQPConnectionError

def send_message(message, queue_name='default_queue'):
    # Проверка, что текст сообщения не пустой
    if not message:
        return "Ошибка: Текст сообщения пустой"

    # Параметры подключения к брокеру сообщений
    connection_params = pika.ConnectionParameters('localhost')

    try:
        # Подключение к брокеру сообщений
        connection = pika.BlockingConnection(connection_params)
        channel = connection.channel()

        # Создание очереди, если она еще не существует
        channel.queue_declare(queue=queue_name)

        # Отправка сообщения
        channel.basic_publish(exchange='',
                              routing_key=queue_name,
                              body=message)

        # Закрытие соединения
        connection.close()

        return "Сообщение успешно отправлено"
    except AMQPConnectionError:
        return "Ошибка: Брокер сообщений недоступен"

# Пример использования
message = "Привет, это тестовое сообщение!"
result = send_message(message)
print(result)
