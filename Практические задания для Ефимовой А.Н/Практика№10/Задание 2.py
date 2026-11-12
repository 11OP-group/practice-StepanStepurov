number_1 = int(input("Введите первое число: "))

while True:
    number_2 = int(input("Введите второе число: "))
    if number_2 <= number_1:
        print("Ошибка! Повторите попытку.")
        continue
    break

while True:
    number_3 = int(input("Введите третье число: "))
    if number_3 <= number_2:
        print("Ошибка! Повторите попытку.")
        continue
    break