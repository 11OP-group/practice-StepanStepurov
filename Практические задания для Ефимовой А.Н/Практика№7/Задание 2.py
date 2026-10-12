from random import randint

status = input("Введите статус заказа: ").strip()

match status:
    case "pending":
        name, desc = "В ожидании ⏳", "Заказ ожидает обработки"
        time = f"{randint(1, 3)} ч"
        advice = "Дождитесь начала обработки заказа"
    case "processing":
        name, desc = "В обработке ⚙️", "Заказ собирается на складе"
        time = f"{randint(1, 2)}-{randint(3, 4)} дня"
        advice = "Проверьте правильность адреса доставки"
    case "shipped":
        name, desc = "Отправлено ✈️", "Ваш заказ находится в пути к вам"
        time = f"{randint(2, 3)}-{randint(4, 5)} дней"
        advice = "Следите за уведомлениями о доставке"
    case "delivered":
        name, desc, time = "Доставлено ✅", "Заказ получен", "—"
        advice = "Оставьте отзыв о покупке"
    case "cancelled":
        name, desc, time = "Отменено ❌", "Заказ отменён", "—"
        advice = "Свяжитесь с поддержкой, если отмена не ваша"
    case _:  # неизвестный статус: сообщение об ошибке и выход
        exit(f'❌ Ошибка: неизвестный статус "{status}"\n'
             "Доступные статусы: "
             "pending, processing, shipped, delivered, cancelled")

print(f"""
╔══════════════════════════════╗
║  📦 СТАТУС ВАШЕГО ЗАКАЗА 📦  ║
╚══════════════════════════════╝

Статус: {name}
Описание: {desc}
Примерное время: {time}
Рекомендация: {advice}""")
