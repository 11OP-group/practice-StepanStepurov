import math

def calculate_distance(x1, y1, x2, y2):
    """Находит расстояние между двумя точками."""
    return math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2)

def calculate_pramoygolnik_S(a, b, c):
    """Находит площадь треугольника."""
    p = (a + b + c) / 2
    return math.sqrt(p * (p - a) * (p - b) * (p - c))


x1, y1 = map(float, input("Точка A: ").split())
x2, y2 = map(float, input("Точка B: ").split())
x3, y3 = map(float, input("Точка C: ").split())

a = calculate_distance(x1, y1, x2, y2)
b = calculate_distance(x2, y2, x3, y3)
c = calculate_distance(x3, y3, x1, y1)

S = calculate_pramoygolnik_S(a, b, c)

print(f"Площадь треугольника: {S:.2f}")