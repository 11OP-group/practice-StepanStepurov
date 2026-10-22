otvet = "Чётное"

# Вводим 10 чисел
for i in range(10):
    chislo = int(input("Введите число: "))

    # Проверяем, чётное ли число
    if chislo % 2 != 0:
        otvet = "Нечётное"

print(otvet)