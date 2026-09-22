# 1. Список — изменяемый тип данных
list = [1,2,3]
print(list)
list[0]=100
print(list)

# 2. Кортеж — неизменяемый тип данных - НЕЛЬЗЯ ИЗМЕНИТЬ - ОШИБКА
list = (1,2,3)
print(list)
list[0]=100
print(list)

# 3. Строка — неизменяемый тип данных - НЕЛЬЗЯ ИЗМЕНИТЬ - ОШИБКА
stroka = "cat"
print(stroka)
stroka[0] = "b"
print(stroka)