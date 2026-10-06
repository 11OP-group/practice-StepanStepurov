stolbec1 = int(input("Введите столбец первой клетки: "))
stroka1 = int(input("Введите строку первой клетки: "))
stolbec2 = int(input("Введите столбец второй клетки: "))
stroka2 = int(input("Введите строку второй клетки: "))

if not (1 <= stolbec1 <= 8 and 1 <= stroka1 <= 8 and
        1 <= stolbec2 <= 8 and 1 <= stroka2 <= 8):
    print("ошибка ввода")

elif (stolbec1 + stroka1) % 2 == (stolbec2 + stroka2) % 2:
    print("YES")

else:
    print("NO")