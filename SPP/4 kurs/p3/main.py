import requests
from bs4 import BeautifulSoup

url = 'https://sterilno.com/catalog/tovary-dlya-vzroslyh.html'

response = requests.get(url)
html_content = response.content

soup = BeautifulSoup(html_content, 'html.parser')

products = soup.find_all('div', class_='main__catalog__item')

# Извлекаем имена и цены товаров
product_list = []
for product in products:
    name = product.find('p', class_='main__catalog__item__trademark').text.strip() # имя
    price_text = product.find('span', class_='numeral').text.strip() # цена
    
    # Преобразуем цену в число
    price = float(price_text.replace('€', '').replace('$', '').replace(',', '').strip())
    
    # Добавляем товар в список
    product_list.append((name, price))

# Сортируем товары по цене
sorted_products = sorted(product_list, key=lambda x: x[1])

print("3 самых дешевых товара:")
for product in sorted_products[:3]:
    print(f"{product[0]} - {product[1]}")

print("\n3 самых дорогих товара:")
for product in sorted_products[-3:]:
    print(f"{product[0]} - {product[1]}")
