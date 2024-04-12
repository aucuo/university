import requests
import pika
import json

# API ключ от OpenWeatherMap
api_key = '19a1a9363d3d466053255773a04b1019'

# Функция для получения данных о погоде
def get_weather(api_key, city):
    base_url = 'https://api.openweathermap.org/data/2.5/weather'
    params = {'q': city, 'appid': api_key, 'units': 'metric'}  # Метрические единицы (градусы Цельсия)
    response = requests.get(base_url, params=params)
    data = response.json()
    return data

# Установка соединения с брокером сообщений
connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
channel = connection.channel()

# Создание очереди для сообщений о погоде
channel.queue_declare(queue='weather_queue')

# Город для получения погоды
city = 'Minsk'

# Получение данных о погоде
weather_data = get_weather(api_key, city)

# Отправка сообщения в формате JSON
message = json.dumps(weather_data)
channel.basic_publish(exchange='', routing_key='weather_queue', body=message)

print("Сообщение о погоде успешно отправлено")
connection.close()
