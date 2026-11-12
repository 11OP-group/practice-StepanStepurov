summa = 0

while True:
    stoimost = int(input("Введите стоимость: "))

    if stoimost == 0:
        break

    summa += stoimost

    if summa > 1000:
        skidka = summa * 0.1
        summa -= skidka

print("Итоговая сумма:", summa)