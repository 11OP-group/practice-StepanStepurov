nomer = int(input("Введи номер места: "))

if nomer < 1 or nomer > 36:
    print("В вагоне 36 мест!!!!!")
else:
    print("Проверка...")
    nomer_kype = (nomer - 1) // 4 + 1
    print("Секунду...")
    print(f" Вот ваш номер купе: {nomer_kype} ")