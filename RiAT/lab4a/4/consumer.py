from confluent_kafka import Consumer
import json

# Конфигурация консьюмера
consumer_config = {
    'bootstrap.servers': 'pkc-75m1o.europe-west3.gcp.confluent.cloud:9092',
    'sasl.mechanisms': 'PLAIN',
    'security.protocol': 'L3IZ625VNZPR4NWA',
    'sasl.username': 'YOUR_API_KEY',
    'sasl.password': 'SjPSCewYsiXODGA3HbvceEPw4X/v9OjfAZmN755ZiYnEgMAnlbrtN8R70eFU1sum',
    'group.id': 'bank-transactions-group',
    'auto.offset.reset': 'earliest'
}

consumer = Consumer(consumer_config)
consumer.subscribe(['bank-transactions'])

# Чтение и обработка сообщений
while True:
    msg = consumer.poll(1.0)

    if msg is None:
        continue
    if msg.error():
        print("Consumer error: {}".format(msg.error()))
        continue

    transaction = json.loads(msg.value().decode('utf-8'))
    print(f"Received transaction: {transaction}")

consumer.close()

# key: L3IZ625VNZPR4NWA
# secret: SjPSCewYsiXODGA3HbvceEPw4X/v9OjfAZmN755ZiYnEgMAnlbrtN8R70eFU1sum