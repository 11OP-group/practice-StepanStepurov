maximum = 0

while True:
    number = int(input("Введите число: "))

    if number == 0:
        break
    elif number > maximum:
        maximum = number

print("Максимальное число:", maximum)