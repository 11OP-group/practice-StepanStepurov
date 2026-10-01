ves, rost = map(float, input("Введите вес и рост: ").split())

imt = ves / (rost ** 2)

print(f"Ваш ИМТ: {imt:.1f}")