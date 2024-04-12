const express = require('express');
const bodyParser = require('body-parser');
const app = express();
const PORT = 3000;

app.use(bodyParser.json());

let products = [];
let nextProductId = 1;

// Эндпоинт для создания нового товара
app.post('/api/products', (req, res) => {
  const newProduct = {
    id: nextProductId++,
    name: req.body.name,
    price: req.body.price,
    description: req.body.description,
  };

  products.push(newProduct);
  res.status(201).json(newProduct);
});

// Эндпоинт для получения списка всех товаров
app.get('/api/products', (req, res) => {
  res.status(200).json(products);
});

// Эндпоинт для получения товара по ID
app.get('/api/products/:id', (req, res) => {
  const productId = parseInt(req.params.id);
  const product = products.find(p => p.id === productId);

  if (product) {
    res.status(200).json(product);
  } else {
    res.status(404).json({ message: 'Product not found' });
  }
});

// Эндпоинт для обновления товара по ID
app.put('/api/products/:id', (req, res) => {
  const productId = parseInt(req.params.id);
  const product = products.find(p => p.id === productId);

  if (product) {
    product.name = req.body.name || product.name;
    product.price = req.body.price || product.price;
    product.description = req.body.description || product.description;

    res.status(200).json(product);
  } else {
    res.status(404).json({ message: 'Product not found' });
  }
});

// Эндпоинт для удаления товара по ID
app.delete('/api/products/:id', (req, res) => {
  const productId = parseInt(req.params.id);
  products = products.filter(p => p.id !== productId);
  res.status(204).end();
});

// Слушаем порт
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
