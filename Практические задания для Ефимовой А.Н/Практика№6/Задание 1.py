temperatura = float(input("Введите температуру: "))
davlenie = int(input("Введите верхнее давление: "))
puls = int(input("Введите пульс: "))

if temperatura < 35 or temperatura > 38 or davlenie < 105 or davlenie > 140 or puls < 55 or puls > 110:
    sostoyanie = "Требуется врач"

elif 35 <= temperatura <= 38 and 105 <= davlenie <= 140 and 55 <= puls <= 110:
    sostoyanie = "Легкое недомогание"

else:
    sostoyanie = "Нормальное состояние"

print(f"Состояние: {sostoyanie}")