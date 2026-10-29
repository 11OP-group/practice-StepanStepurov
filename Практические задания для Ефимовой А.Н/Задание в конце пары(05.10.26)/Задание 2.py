a = int(input("Введите сторону 1: "))
b = int(input("Введите сторону 2: "))
c = int(input("Введите сторону 3: "))

if a + b <= c or a + c <= b or b + c <= a:
    print(f"Ошибка: такого треугольника не существует")
elif a == b and b == c:
    print(f"Тип: Равносторонний")
elif a == b or a == c or b == c:
    print(f"Тип: Равнобедренный")
else:
    print(f"Тип: Разносторонний")