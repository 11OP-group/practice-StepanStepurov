imya = input()
schet = 0

while imya != 'Левон':
    if imya == 'Александра':
        schet = 0
    elif schet >= 0:
        schet += 1

    imya = input()

print(schet)