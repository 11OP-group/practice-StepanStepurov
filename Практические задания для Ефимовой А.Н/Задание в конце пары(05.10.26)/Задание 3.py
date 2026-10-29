month = int(input("Введите номер месяца: "))

if month == 2:
    print(f"Количество дней: 28")
elif month == 4 or month == 6 or month == 9 or month == 11:
    print(f"Количество дней: 30")
else:
    print(f"Количество дней: 31")