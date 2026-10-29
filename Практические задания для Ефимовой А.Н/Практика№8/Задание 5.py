kolichestvo = int(input())

# Вводим первое число
chislo = int(input())
max1 = chislo
max2 = 0

# Находим два самых больших числа
for i in range(kolichestvo - 1):
    chislo = int(input())

    if chislo > max1:
        max2 = max1
        max1 = chislo
    elif chislo > max2:
        max2 = chislo

print(max1)
print(max2)