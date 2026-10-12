status = input("Введите статус заказа: ")

print("╔══════════════════════════════╗")
print("║  📦 СТАТУС ВАШЕГО ЗАКАЗА 📦  ║")
print("╚══════════════════════════════╝")
print()

match status:

    case "pending":
        print("Статус: В ожидании ⏳")
        print("Описание: Заказ ожидает обработки")
        print("Примерное время: 2 ч")

    case "processing":
        print("Статус: В обработке ⚙️")
        print("Описание: Заказ собирается на складе")
        print("Примерное время: 1 день")

    case "shipped":
        print("Статус: Отправлено ✈️")
        print("Описание: Заказ в пути к вам")
        print("Примерное время: 3 дня")

    case "delivered":
        print("Статус: Доставлено ✅")
        print("Описание: Заказ получен")
        print("Примерное время: —")

    case "cancelled":
        print("Статус: Отменено ❌")
        print("Описание: Заказ отменён")
        print("Примерное время: —")

    case _:
        print(f"❌ Ошибка: Неизвестный статус {status}")
        print("Доступные статусы: pending, processing, shipped, delivered, cancelled")
