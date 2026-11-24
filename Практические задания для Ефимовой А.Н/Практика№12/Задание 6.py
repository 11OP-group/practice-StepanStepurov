# 5tepa7g

slovo = input("Введите слово: ")

spisok_bukv = list(slovo)
perevernutiy_spisok = spisok_bukv[::-1]

# Сравниваем исходный и перевернутый списки

if spisok_bukv == perevernutiy_spisok:
    rezultat = print(f"Слово {slovo}: Это палиндром")
else:
    rezultat = print(f"Слово {slovo}: Не палиндром")



