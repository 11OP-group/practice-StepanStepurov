# Автор: 5tepa7g

for byki in range(11):
    for korovy in range(21):
        for telyata in range(201):
            if 20 * byki + 10 * korovy + telyata == 200:
                if byki + korovy + telyata > 0:
                    print("Быков:", byki)
                    print("Коров:", korovy)
                    print("Телят:", telyata)
                    print()
