# Задача 2. Отслеживание заказа
import random

status = input("Введите статус заказа: ")

# Случайное время ожидания
days = random.randint(2, 5)
hours = random.randint(1, 3)

# Рамка
print("╔══════════════════════════════╗")
print("║  📦 СТАТУС ВАШЕГО ЗАКАЗА 📦  ║")
print("╚══════════════════════════════╝")

match status:
    case "pending":
        print("Статус: В ожидании ⏳")
        print("Описание: Заказ принят и ожидает обработки")
        print(f"Примерное время: {hours} ч")
    case "processing":
        print("Статус: В обработке ⚙️")
        print("Описание: Ваш заказ собирается на складе")
        print(f"Примерное время: {hours} ч")
    case "shipped":
        print("Статус: Отправлено ✈️")
        print("Описание: Ваш заказ находится в пути к вам")
        print(f"Примерное время: {days} дн.")
    case "delivered":
        print("Статус: Доставлено ✅")
        print("Описание: Заказ получен")
        print("Примерное время: —")
    case "cancelled":
        print("Статус: Отменено ❌")
        print("Описание: Заказ был отменён")
        print("Примерное время: —")
    case _:
        # Неизвестный статус
        print(f'❌ Ошибка: Неизвестный статус "{status}"')
        print("Доступные статусы: pending, processing, shipped, delivered, cancelled")