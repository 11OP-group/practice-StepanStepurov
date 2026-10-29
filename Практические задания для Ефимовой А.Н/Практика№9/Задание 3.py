cena = int(input())
moneta = 0

while cena >= 25:
    cena -= 25
    moneta += 1

while cena >= 10:
    cena -= 10
    moneta += 1

while cena >= 5:
    cena -= 5
    moneta += 1

while cena >= 1:
    cena -= 1
    moneta += 1

print(moneta)