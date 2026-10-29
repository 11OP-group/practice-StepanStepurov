ocenka = int(input())
pyaterki = 0
while ocenka > 0 and ocenka <= 5:
    if ocenka == 5:
        pyaterki = pyaterki + 1
    ocenka = int(input())
print(pyaterki)