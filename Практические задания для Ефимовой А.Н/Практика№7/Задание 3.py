# Задача 3. Интерактивное меню кафе

# Цены (константы)
COFFEE = 120
TEA = 80
JUICE = 100
WATER = 50
LEMONADE = 90

print("1 Кофе ☕ 120 | 2 Чай 🍵 80 | 3 Сок 🧃 100 | 4 Вода 💧 50 | 5 Лимонад 🥤 90")
choice = input("Введите номер (1-5) или название напитка: ").lower()

# Выбор напитка
match choice:
    case "1" | "кофе":
        name, emoji, price = "Кофе", "☕", COFFEE
    case "2" | "чай":
        name, emoji, price = "Чай", "🍵", TEA
    case "3" | "сок":
        name, emoji, price = "Сок", "🧃", JUICE
    case "4" | "вода":
        name, emoji, price = "Вода", "💧", WATER
    case "5" | "лимонад":
        name, emoji, price = "Лимонад", "🥤", LEMONADE
    case _:
        print("❌ Ошибка: такого напитка нет в меню")
        exit()

# Проверка количества порций
count = input("Количество порций: ")
match count.isdigit():
    case True:
        count = int(count)
    case _:
        print("❌ Ошибка: введите число")
        exit()

# Согласование слова "порция"
match count:
    case 0:
        print("❌ Ошибка: количество должно быть больше 0")
        exit()
    case 1:
        word = "порция"
    case 2 | 3 | 4:
        word = "порции"
    case _:
        word = "порций"

# Код скидки
code = input("Код скидки (Enter - если нет): ")
match code:
    case "STUDENT":
        percent = 20
    case "":
        percent = 0
    case _:
        print("⚠️ Такого кода нет, скидки не будет")
        percent = 0

# Расчёт
total = price * count
discount = total * percent // 100
final = total - discount

# Квитанция
print("╔══════════════════════════════╗")
print(f"║     {emoji} КВИТАНЦИЯ КАФЕ {emoji}     ║")
print("╚══════════════════════════════╝")
print(f"Товар: {name} {emoji}")
print(f"Цена за порцию: {price} руб")
print(f"Количество: {count} {word}")
print(f"Сумма: {total} руб")
print(f"Скидка ({percent}%): -{discount} руб")
print("════════════════════════════════")
print(f"💰 К ОПЛАТЕ: {final} руб")
print("════════════════════════════════")