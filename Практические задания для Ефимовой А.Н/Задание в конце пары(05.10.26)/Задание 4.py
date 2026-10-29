weight = int(input("Введите вес: "))

if weight < 60:
    print(f"Категория: Легкий вес")
elif weight < 64:
    print(f"Категория: Первый полусредний вес")
else:
    print(f"Категория: Полусредний вес")