n = int(input("Введите n: "))
summa = 0

# Считаем сумму с чередованием знаков
for chislo in range(1, n + 1):
    if chislo % 2 == 0:
        summa -= chislo
    else:
        summa += chislo

print(summa)