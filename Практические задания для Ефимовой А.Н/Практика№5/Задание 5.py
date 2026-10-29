amount = int(input("Введите сумму: "))

bills_5000 = amount // 5000
amount = amount % 5000

bills_2000 = amount // 2000
amount = amount % 2000

bills_1000 = amount // 1000
amount = amount % 1000

bills_500 = amount // 500
amount = amount % 500

bills_200 = amount // 200
amount = amount % 200

bills_100 = amount // 100

print(f"5000 руб.: {bills_5000} шт.")
print(f"2000 руб.: {bills_2000} шт.")
print(f"1000 руб.: {bills_1000} шт.")
print(f"500 руб.: {bills_500} шт.")
print(f"200 руб.: {bills_200} шт.")
print(f"100 руб.: {bills_100} шт.")