import math

x = float(input("Введите угол x в градусах: "))
r = x * math.pi / 180

result = math.sin(r) + math.cos(r) + math.tan(r) ** 2

print("Результат:", result)