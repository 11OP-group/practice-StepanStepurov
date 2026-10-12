COFFEE, TEA, JUICE, WATER, LEMONADE = 120, 80, 100, 50, 90  # цены, руб

print("1 Кофе ☕ 120 | 2 Чай 🍵 80 | 3 Сок 🧃 100 | "
      "4 Вода 💧 50 | 5 Лимонад 🥤 90\n")
choice = input("Введите номер (1-5) или название напитка: ").strip().lower()

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
        exit("❌ Ошибка: такого напитка нет в меню")

count = input("Количество порций: ").strip()
if not count.isdecimal():  # isdecimal не пропускает символы вроде "²"
    exit("❌ Ошибка: введите число")
count = int(count)

match count:  # согласование слова «порция»
    case 0:
        exit("❌ Ошибка: количество должно быть больше 0")
    case 1:
        word = "порция"
    case 2 | 3 | 4:
        word = "порции"
    case _:
        word = "порций"

code = input("Код скидки (Enter - если нет): ").strip()

match code:
    case "STUDENT":
        percent = 20
    case "":
        percent = 0
    case _:
        percent = 0
        print("⚠️ Такого кода нет, скидки не будет")

total = price * count
discount = total * percent // 100

print(f"""
╔══════════════════════════════╗
║     {emoji} КВИТАНЦИЯ КАФЕ {emoji}     ║
╚══════════════════════════════╝

Товар: {name} {emoji}
Цена за порцию: {price} руб
Количество: {count} {word}
Сумма: {total} руб
Скидка ({percent}%): -{discount} руб

════════════════════════════════
💰 К ОПЛАТЕ: {total - discount} руб
════════════════════════════════""")final = total - discount

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
