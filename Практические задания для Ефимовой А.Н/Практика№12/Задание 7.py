# 5tepa7g

numbers = [10, 20, 30, 40, 50]

chislo = int(input("Введите число: "))

for i in range(len(numbers)):
    if numbers[i] == chislo:
        print(f"Индекс: {i}")
        break
else:
    print("Нет такого числа")