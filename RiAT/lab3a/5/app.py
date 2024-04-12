from flask import Flask, jsonify, request
from flask_jwt_extended import JWTManager, create_access_token, jwt_required, get_jwt_identity
import requests

app = Flask(__name__)
app.config['JWT_SECRET_KEY'] = 'super-secret'  # Задайте свой секретный ключ
jwt = JWTManager(app)

# Предполагаемая база данных пользователей
users = [
    {'id': 1, 'username': 'user1', 'password': 'abcxyz'},
    {'id': 2, 'username': 'user2', 'password': 'abcxyz'}
]

# Функция для получения APOD от NASA API
def get_apod(api_key):
    url = f"https://api.nasa.gov/planetary/apod?api_key={api_key}"
    response = requests.get(url)
    return response.json() if response.status_code == 200 else None

# Регистрация или вход пользователя
@app.route('/login', methods=['POST'])
def login():
    username = request.json.get('username', None)
    password = request.json.get('password', None)
    user = next((u for u in users if u['username'] == username and u['password'] == password), None)
    if user is None:
        return jsonify({"msg": "Bad username or password"}), 401

    access_token = create_access_token(identity=username)
    return jsonify(access_token=access_token)

# Защищенный маршрут для получения APOD
@app.route('/apod', methods=['GET'])
@jwt_required()
def apod():
    api_key = "DxyNq9HXiIOkN1JS8yrAcQZ9a7J83SUZAHPFkHVp"  # Замените YOUR_NASA_API_KEY на ваш API ключ
    apod_data = get_apod(api_key)
    if apod_data:
        return jsonify(apod_data)
    else:
        return jsonify({"msg": "Error fetching APOD data"}), 500

if __name__ == '__main__':
    app.run(debug=True)


# eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTcwMTgxNjgxNCwianRpIjoiOTRlNjNkYTItMDQ2MC00M2RmLTkwMzUtZTRiNjk2MDQ1M2U1IiwidHlwZSI6ImFjY2VzcyIsInN1YiI6InVzZXIxIiwibmJmIjoxNzAxODE2ODE0LCJleHAiOjE3MDE4MTc3MTR9.69LkkL6UTIHxukO76AYAf1IlSL7xg5kvNO2BrUXRdAQ
