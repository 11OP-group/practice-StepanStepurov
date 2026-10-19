# Получаем первое число A
A = int(input())

# Получаем второе число B
B = int(input())

# Рекурсивная функция для подсчёта сумм
# i — текущее число
# sum_even — сумма чётных
# sum_odd — сумма нечётных
def calc(i, sum_even, sum_odd):
    # Базовый случай: если i больше B — возвращаем разность
    if i > B:
        return sum_even - sum_odd
    # Если число чётное
    if i % 2 == 0:
        # Прибавляем к сумме чётных и идём дальше
        return calc(i + 1, sum_even + i, sum_odd)
    else:
        # Прибавляем к сумме нечётных и идём дальше
        return calc(i + 1, sum_even, sum_odd + i)

# Запускаем рекурсию с начальными значениями
result = calc(A, 0, 0)

# Выводим результат
print(result)