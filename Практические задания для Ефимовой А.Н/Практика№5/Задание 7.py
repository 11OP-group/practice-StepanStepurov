FUEL_PRICE = 71.01


def calculate_stoimost_poezdki(distance, fuel):
    """Рассчитывает стоимость поездки."""
    fuel_needed = distance * fuel / 100
    return fuel_needed, fuel_needed * FUEL_PRICE


distance, fuel = map(float, input("Расстояние и расход: ").split())

fuel_needed, poezdka = calculate_stoimost_poezdki(distance, fuel)

print(f"Бензина нужно: {fuel_needed:.2f} л")
print(f"Стоимость: {poezdka:.2f} руб.")
