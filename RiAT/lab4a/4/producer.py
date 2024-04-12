from confluent_kafka import Producer
import json

# Конфигурация продюсера
producer_config = {
    'bootstrap.servers': 'pkc-75m1o.europe-west3.gcp.confluent.cloud:9092', # Укажите серверы из Confluent Cloud
    'sasl.mechanisms': 'PLAIN',
    'security.protocol': 'SASL_SSL',
    'sasl.username': 'L3IZ625VNZPR4NWA',
    'sasl.password': 'SjPSCewYsiXODGA3HbvceEPw4X/v9OjfAZmN755ZiYnEgMAnlbrtN8R70eFU1sum'
}

producer = Producer(producer_config)

# Отправка сообщения
def delivery_report(err, msg):
    if err is not None:
        print('Message delivery failed: {}'.format(err))
    else:
        print('Message delivered to {} [{}]'.format(msg.topic(), msg.partition()))

# Симулируем отправку банковской транзакции
transaction = {'amount': 1000, 'transaction': 'deposit'}
producer.produce('bank-transactions', json.dumps(transaction), callback=delivery_report)
producer.poll(0)
producer.flush()
