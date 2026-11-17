# Автор: 5tepa7g

for n in range(1, 13):
    for k in range(1, 13):
        for m in range(1, 13):
            if n + k + m == 12 and 28 * n + 30 * k + 31 * m == 365:
                print("n =", n, "k =", k, "m =", m)
