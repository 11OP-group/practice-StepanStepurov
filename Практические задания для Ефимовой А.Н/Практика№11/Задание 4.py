# Автор: 5tepa7g

chislo = int(input("Введите натуральное число: "))

poslednyaya = chislo % 10
kopiya = chislo

troiki = 0
poslednie = 0
chetnye = 0
summa = 0
proizvedenie = 1
nuli_pyaterki = 0

while kopiya > 0:
    cifra = kopiya % 10

    if cifra == 3:
        troiki += 1

    if cifra == poslednyaya:
        poslednie += 1

    if cifra % 2 == 0:
        chetnye += 1

    if cifra > 5:
        summa += cifra

    if cifra > 7:
        proizvedenie *= cifra

    if cifra == 0 or cifra == 5:
        nuli_pyaterki += 1

    kopiya = kopiya // 10

print(troiki)
print(poslednie)
print(chetnye)
print(summa)
print(proizvedenie)
print(nuli_pyaterki)
