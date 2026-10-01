zarplata = float(input("Введите свой годовой доход: "))
nalog = (zarplata * 13 // 100)
nalog_vse = (zarplata - nalog)

print (f"Общая сумма дохода: {zarplata: .2f} ")
print (f"Сумма рассчитанного налога: {nalog: .2f} ")
print (f"Сумма «на руки» после вычета налога: {nalog_vse: .2f} ")