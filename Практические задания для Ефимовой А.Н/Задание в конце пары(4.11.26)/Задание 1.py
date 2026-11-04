popitki = 0
while True:

 password = input("Введите пароль: ")
 print(password)

 popitki += 1

 if password == "admin":

     print("Доступ Разрешен")
     break

 elif popitki >= 3:

    print("Вход заблокирован")
    break