cifra = int(input())

tiashi = cifra // 1000
sotni = (cifra // 100) - tiashi * 10
desatki = (cifra // 10) - (cifra // 100) * 10
edenic = cifra- (cifra // 10) * 10

print(f" Позиция тысячи {tiashi}")
print(f"Позиция сотен {sotni}")
print(f"Позиция десятков {desatki}")
print(f"Позиция едениц {edenic}")