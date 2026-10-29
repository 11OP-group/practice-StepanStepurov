n = str(input("Введи кол-во школьников: "))
k = str(input("Введи кол-во мандаринов: "))

n = int(n)
k = int(k)

cel = k // n
ostatok = k % n

print(f"Досталось каждому школьнику: {cel}")
print(f"Осталось мандаринов в корзине:  {ostatok}")