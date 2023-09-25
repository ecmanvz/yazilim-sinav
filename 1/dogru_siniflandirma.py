
noktalar = [(1, 2), (3, 7), (0, 6), (1, 1), (-5, 2), (1, 5), (3, -5)]

doğru_y_paralel = 0
doğru_x_paralel = 0

geçen_doğrular = set()

for i in range(len(noktalar)):
    nokta1 = noktalar[i]
    x1, y1 = nokta1
    
    for j in range(i+1, len(noktalar)):
        nokta2 = noktalar[j]
        x2, y2 = nokta2
        
        if x2 - x1 == 0:
            doğru = ("x", x1)
        elif y2 - y1 == 0:
            doğru = ("y", y1)
        else:
            continue
        
        # Bu doğru daha önce eklenmediyse ekleyelim.
        if doğru not in geçen_doğrular:
            geçen_doğrular.add(doğru)
            if doğru[0] == "x":
                doğru_x_paralel += 1
                print(f"Y eksenine paralel doğru: ({x1}, {y1}) - ({x2}, {y2})")
            elif doğru[0] == "y":
                doğru_y_paralel += 1
                print(f"X eksenine paralel doğru: ({x1}, {y1}) - ({x2}, {y2})")

print(f"X eksenine paralel doğru sayısı: {doğru_y_paralel}")
print(f"Y eksenine paralel doğru sayısı: {doğru_x_paralel}")
