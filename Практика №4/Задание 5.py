minutes = int(input("Введи количесвто минут: "))

hours = minutes // 60
ostatok = minutes % 60

print(f"{minutes} минуты - это {hours} час {ostatok} минут.")