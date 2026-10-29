n = int(input())
chislo = 1

while chislo <= n:
    if 5 <= chislo <= 9 or 17 <= chislo <= 37 or 78 <= chislo <= 87:
        chislo += 1
        continue

    print(chislo)
    chislo += 1