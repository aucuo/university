import socket
import threading

# Настройка клиента
nickname = input("Введите ваш псевдоним: ")

client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect(('127.0.0.1', 12345))

# Функция для получения сообщений от сервера
def receive():
    while True:
        try:
            message = client.recv(1024).decode('utf-8')
            if message == 'NICK':
                client.send(nickname.encode('utf-8'))
            else:
                print(message)
        except:
            # Закрытие соединения при ошибке
            print("Ошибка! Соединение закрыто.")
            client.close()
            break

# Функция для отправки сообщений на сервер
def write():
    while True:
        message = f'{nickname}: {input("")}'
        client.send(message.encode('utf-8'))

# Запускаем потоки для отправки и получения сообщений
receive_thread = threading.Thread(target=receive)
receive_thread.start()

write_thread = threading.Thread(target=write)
write_thread.start()
