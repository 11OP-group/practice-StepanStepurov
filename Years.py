import calendar
def main():
    user_input = input("Введите год (например, 2024): ")
    if not user_input.isdigit():
        print("Ошибка: введите целое положительное число.")
        return
    year = int(user_input)
    is_leap = calendar.isleap(year)
    print("\n" + "=" * 40)
    if is_leap:
        print(f"Результат: {year} год — ВИСОКОСНЫЙ (366 дней)")
    else:
        print(f"Результат: {year} год — НЕВИСОКОСНЫЙ (365 дней)")
    print("=" * 40 + "\n")
    print(f"Календарь на {year} год:\n")
    print(calendar.calendar(year))
if __name__ == "__main__":
    main()