# Автор: 5tepa7g

pary = {}

for a in range(1, 151):
    for b in range(a, 151):
        summa = a ** 5 + b ** 5

        if summa not in pary:
            pary[summa] = (a, b)

naideno = False

for e in range(1, 151):
    for c in range(1, 151):
        for d in range(c, 151):
            ostatok = e ** 5 - c ** 5 - d ** 5

            if ostatok in pary:
                a, b = pary[ostatok]

                print("a =", a)
                print("b =", b)
                print("c =", c)
                print("d =", d)
                print("e =", e)
                print("Сумма =", a + b + c + d + e)

                naideno = True
                break

        if naideno:
            break

    if naideno:
        break
