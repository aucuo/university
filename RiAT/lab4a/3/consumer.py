import pika
import json

# Функция для обработки полученного сообщения
def callback(ch, method, properties, body):
    weather_data = json.loads(body)
    print("Полученные данные о погоде:")
    print(f"Город: {weather_data['name']}")
    print(f"Температура: {weather_data['main']['temp']}°C")
    print(f"Описание: {weather_data['weather'][0]['description']}\n")

# Установка соединения с брокером сообщений
connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
channel = connection.channel()

# Создание очереди для сообщений о погоде
channel.queue_declare(queue='weather_queue')

# Подписка на очередь и обработка сообщений
channel.basic_consume(queue='weather_queue', on_message_callback=callback, auto_ack=True)

print('Ожидание сообщений о погоде. Для выхода нажмите CTRL+C')
channel.start_consuming()
