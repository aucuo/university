import requests
import pika

# API ключ от OpenWeatherMap
api_key = '19a1a9363d3d466053255773a04b1019'

# Функция для получения данных о погоде
def get_weather(api_key, city):
    base_url = 'https://api.openweathermap.org/data/2.5/weather'
    params = {'q': city, 'appid': api_key, 'units': 'metric'}  # Метрические единицы (градусы Цельсия)
    response = requests.get(base_url, params=params)
    data = response.json()
    return data

# Функция для отправки сообщения в очередь брокера сообщений
def send_weather_message(message, queue_name='weather_queue'):
    connection_params = pika.ConnectionParameters('localhost')
    try:
        connection = pika.BlockingConnection(connection_params)
        channel = connection.channel()
        channel.queue_declare(queue=queue_name)
        channel.basic_publish(exchange='', routing_key=queue_name, body=message)
        connection.close()
        return "Сообщение о погоде успешно отправлено"
    except pika.exceptions.AMQPConnectionError:
        return "Ошибка: Брокер сообщений недоступен"

# Город для получения погоды
city = 'Minsk'

# Получение данных о погоде
weather_data = get_weather(api_key, city)

# Формирование сообщения
message = f"Текущая погода в городе {city}: {weather_data['weather'][0]['description']}, Температура: {weather_data['main']['temp']}°C"

# Отправка сообщения
result = send_weather_message(message)
print(result)
