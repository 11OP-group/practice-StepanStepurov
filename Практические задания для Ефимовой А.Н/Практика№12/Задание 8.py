# 5tepa7g

import random

numbers = [random.randint(1, 100) for i in range(5)]

print(f"Исходный список: {numbers}")

min_index = numbers.index(min(numbers))

numbers[0], numbers[min_index] = numbers[min_index], numbers[0]

print(f"Результат: {numbers}")