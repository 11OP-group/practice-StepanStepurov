import random

zagadka = random.randint(1, 10)  # случайное целое от 1 до 10 включительно

# Даём 3 попытки
for i in range(3):
    otvet = int(input("Угадайте число от 1 до 10: "))

    if otvet == zagadka:
        print("Угадали!")
        break
    else:
        print("Неверно")

        # Подсказываем, куда двигаться
        if otvet < zagadka:
            print("Больше")
        else:
            print("Меньше")
else:
    print(f"Правильный ответ: {zagadka}")