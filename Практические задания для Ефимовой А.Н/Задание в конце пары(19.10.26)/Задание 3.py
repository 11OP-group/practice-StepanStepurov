m = int(input("Введите m: "))
n = int(input("Введите n: "))

if m < n:
    for i in range(m, n + 1):
        print(i)
else:
    for i in range(m, n - 1, -1):
        print(i)