chislo = int(input())

troiki = 0
poslednyaya = chislo % 10
povtor = 0
chet = 0
summa = 0
proizv = 1
nol_pyat = 0

while chislo > 0:
    cifra = chislo % 10

    if cifra == 3:
        troiki += 1

    if cifra == poslednyaya:
        povtor += 1

    if cifra % 2 == 0:
        chet += 1

    if cifra > 5:
        summa += cifra

    if cifra > 7:
        proizv *= cifra

    if cifra == 0 or cifra == 5:
        nol_pyat += 1

    chislo //= 10

print(troiki)
print(povtor)
print(chet)
print(summa)
print(proizv)
print(nol_pyat)