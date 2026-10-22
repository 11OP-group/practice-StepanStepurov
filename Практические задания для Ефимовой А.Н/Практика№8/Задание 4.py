kolichestvo = int(input("Начальное количество: "))
procent = int(input("Рост в процентах: "))
dni = int(input("Количество дней: "))

# Выводим количество организмов по дням
for den in range(1, dni + 1):
    print(f"{den} {kolichestvo}")
    kolichestvo = kolichestvo + kolichestvo * procent / 100