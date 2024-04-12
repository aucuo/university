import requests

def get_apod(api_key):
    url = f"https://api.nasa.gov/planetary/apod?api_key={api_key}"
    response = requests.get(url)
    if response.status_code == 200:
        return response.json()
    else:
        return None

api_key = "DxyNq9HXiIOkN1JS8yrAcQZ9a7J83SUZAHPFkHVp"  # Замените YOUR_NASA_API_KEY на ваш API ключ
apod_data = get_apod(api_key)

if apod_data:
    print(f"Title: {apod_data['title']}")
    print(f"Date: {apod_data['date']}")
    print(f"Explanation: {apod_data['explanation']}")
    print(f"Image URL: {apod_data['url']}")
else:
    print("Error fetching APOD data")
