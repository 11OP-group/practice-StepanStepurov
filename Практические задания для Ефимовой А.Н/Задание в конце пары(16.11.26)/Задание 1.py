# Автор: # 5tepa7g

prices = [100, 50, 200, 150]

print("Самая дорогая цена:", max(prices))
print("Самая дешёвая цена:", min(prices))

srednee = sum(prices) / len(prices)
print("Средняя цена:", srednee)

print("Цены:")
print(*prices, sep=", ")
