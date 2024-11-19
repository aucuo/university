import requests

# Ваш API-ключ, полученный на OpenWeather
api_key = '0a7e9c7db61e1ffdc7263c6546892703'

# URL для запросов к OpenWeather
base_url = 'http://api.openweathermap.org/data/2.5/weather?'

def get_weather(city):
    complete_url = f"{base_url}q={city}&appid={api_key}&units=metric&lang=ru"

    response = requests.get(complete_url)

    data = response.json()

    if data["cod"] == 200:
        main = data['main']
        weather_description = data['weather'][0]['description']
        temperature = main['temp']
        feels_like = main['feels_like']
        humidity = main['humidity']

        print(f"Город: {city}")
        print(f"Температура: {temperature}°C")
        print(f"Ощущается как: {feels_like}°C")
        print(f"Описание погоды: {weather_description}")
        print(f"Влажность: {humidity}%")
    else:
        print(f"Город {city} не найден.")

city_name = input("Введите название города: ")
get_weather(city_name)
