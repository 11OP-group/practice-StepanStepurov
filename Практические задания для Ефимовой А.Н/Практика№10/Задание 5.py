balans = 0

while True:
yprav = int(input("Выберите команду (1-4): "))

match yprav:
    case 1:
        print("Текущий баланс:", balans)

    case 2:
        if balans >= 100:
            balans -= 100
            print("Снято")
        else:
            print("Недостаточно средств")

    case 3:
        balans += 100
        print("Баланс пополнен")

    case 4:
        print("До свидания")
        break

    case _:
        print("Неверная команда")