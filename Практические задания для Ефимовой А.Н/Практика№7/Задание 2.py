import random

status = input("Введите статус заказа: ").strip()

match status:
    case "pending":
        name = "В ожидании ⏳"
        description = "Заказ ожидает обработки"
        time = f"{random.randint(1, 3)} ч"
        advice = "Дождитесь начала обработки заказа"
    case "processing":
        name = "В обработке ⚙️"
        description = "Заказ собирается на складе"
        time = f"{random.randint(1, 2)}-{random.randint(3, 4)} дня"
        advice = "Проверьте правильность адреса доставки"
    case "shipped":
        name = "Отправлено ✈️"
        description = "Ваш заказ находится в пути к вам"
        time = f"{random.randint(2, 3)}-{random.randint(4, 5)} дней"
        advice = "Следите за уведомлениями о доставке"
    case "delivered":
        name = "Доставлено ✅"
        description = "Заказ получен"
        time = "—"
        advice = "Оставьте отзыв о покупке"
    case "cancelled":
        name = "Отменено ❌"
        description = "Заказ отменён"
        time = "—"
        advice = "Свяжитесь с поддержкой, если отмена не ваша"
    case _:
        name = None

print()
if name is None:
    print(f'❌ Ошибка: Неизвестный статус "{status}"')
    print("Доступные статусы: pending, processing, shipped, delivered, cancelled")
else:
    print("╔══════════════════════════════╗")
    print("║  📦 СТАТУС ВАШЕГО ЗАКАЗА 📦  ║")
    print("╚══════════════════════════════╝")
    print()
    print(f"Статус: {name}")
    print(f"Описание: {description}")
    print(f"Примерное время: {time}")
    print(f"Рекомендация: {advice}")
