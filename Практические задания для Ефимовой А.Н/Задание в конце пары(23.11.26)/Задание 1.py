# 5tepa7g

prices_str = '100 50 200 150 75 300'

prices = prices_str.split()

# Преобразуем в числа
for i in range(len(prices)):
    prices[i] = int(prices[i])

# Удаляем максимальную цену
prices.remove(max(prices))

# Добавляем товар со скидкой 50%
prices.append(max(prices) / 2)

# Сортируем цены
prices.sort()

# Выводим цены
print(f"Цены: {prices}")

# Считаем среднюю цену
print(f"Средняя цена: {sum(prices) / len(prices):.2f}")