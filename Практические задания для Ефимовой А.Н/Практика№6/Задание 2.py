nomer = int(input("Введите номер кармана: "))

if not 0 <= nomer <= 36:
    print("ошибка ввода")
elif nomer == 0:
    print("зеленый")
elif (1 <= nomer <= 10) or (19 <= nomer <= 28):
    if nomer % 2 == 0:
        print("черный")
    else:
        print("красный")
else:
    if nomer % 2 == 0:
        print("красный")
    else:
        print("черный")