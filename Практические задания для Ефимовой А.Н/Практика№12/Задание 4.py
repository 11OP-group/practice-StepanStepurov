# 5tepa7g


marks = [5, 4, 3, 5, 2, 5, 4, 3, 5, 5]

pyaterki = 0
dvoiki = 0

for item in marks:
    if item == 5:
        pyaterki = pyaterki + 1
    elif item == 2:
        dvoiki = dvoiki + 1

vivod_pyaterki = print(f"Количество пятерок: {pyaterki}")
vivod_dvoiki = print(f"Количество двоек: {dvoiki}")




