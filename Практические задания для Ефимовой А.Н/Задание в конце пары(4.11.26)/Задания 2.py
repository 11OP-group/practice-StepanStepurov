n = 0
while True:

 chislo = int(input())

 n += 1
 if chislo >= 0:

    print("Ваше произведение: ", chislo * n)

 else:

    print("Ошибка! - Число отрицательное")
    break