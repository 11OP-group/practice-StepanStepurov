import math

def calculate_pramoygolnik_S(width, height):
    """Считает площадь прямоугольника."""
    return width * height

def calculate_kryg_S(radius):
    """Считает площадь круга."""
    return math.pi * radius * radius

width = float(input("Введите ширину: "))
height = float(input("Введите высоту: "))

pramoygolnik_S = calculate_pramoygolnik_S(width, height)
print(f"Площадь прямоугольника: {pramoygolnik_S:.2f}")

radius = float(input("Введите радиус: "))

kryg_S = calculate_kryg_S(radius)
print(f"Площадь круга: {kryg_S:.2f}")
