from flask import Flask, jsonify, request

app = Flask(__name__)

# Имитация базы данных в памяти
products = [
    {'id': 1, 'name': 'Laptop', 'price': 1000.00, 'description': 'High performance laptop'},
    {'id': 2, 'name': 'Smartphone', 'price': 500.00, 'description': 'Latest model smartphone'},
    {'id': 3, 'name': 'Headphones', 'price': 150.00, 'description': 'Noise cancelling headphones'},
    {'id': 4, 'name': 'Smart Watch', 'price': 300.00, 'description': 'Waterproof smart watch'},
    {'id': 5, 'name': 'Backpack', 'price': 70.00, 'description': 'Durable travel backpack'}
]




# Создание товара
@app.route('/products', methods=['POST'])
def create_product():
    product = request.json
    product['id'] = len(products) + 1
    products.append(product)
    return jsonify(product), 201

# Получение всех товаров
@app.route('/products', methods=['GET'])
def get_products():
    return jsonify(products)

# Получение одного товара по ID
@app.route('/products/<int:product_id>', methods=['GET'])
def get_product(product_id):
    product = next((p for p in products if p['id'] == product_id), None)
    if product is None:
        return jsonify({'message': 'Product not found'}), 404
    return jsonify(product)

# Обновление товара
@app.route('/products/<int:product_id>', methods=['PUT'])
def update_product(product_id):
    product = next((p for p in products if p['id'] == product_id), None)
    if product is None:
        return jsonify({'message': 'Product not found'}), 404
    product_data = request.json
    product.update(product_data)
    return jsonify(product)

# Удаление товара
@app.route('/products/<int:product_id>', methods=['DELETE'])
def delete_product(product_id):
    global products
    products = [p for p in products if p['id'] != product_id]
    return jsonify({'message': 'Product deleted'}), 200

if __name__ == '__main__':
    app.run(debug=True)
