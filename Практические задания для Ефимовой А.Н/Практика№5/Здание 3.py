USD_TO_RUB = 83.38

def convert_usd_to_rub(amount_usd):
    """Переводит доллары в рубли."""
    return amount_usd * USD_TO_RUB


amount_usd = float(input("Введите сумму в долларах: "))

amount_rub = convert_usd_to_rub(amount_usd)

print(f"Сумма в рублях: {amount_rub:.2f} руб.")