correct_password = "4590"
while True:
    password = input("Введите пин-код: ")
    if password == correct_password:
        print("|", password, "|", "Доступ разрешен")
        break
    elif password != correct_password:
        print("|", password, "|", "Ошибка.Попробуйте еще раз")