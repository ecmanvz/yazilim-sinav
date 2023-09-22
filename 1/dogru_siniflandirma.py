noktalar = [(1, 2), (3, 7), (0, 6), (1, 1), (-5, 2), (1, 5), (3, -5)]

doğru_y_paralel = 0
doğru_x_paralel = 0

for i in range(len(noktalar)):
    nokta1 = noktalar[i]
    x1, y1 = nokta1
    
    # Aynı noktalardan geçen doğruları saymak için bir sayaç ekleyelim.
    aynı_nokta_sayac = 1
    
    for j in range(i+1, len(noktalar)):
        nokta2 = noktalar[j]
        x2, y2 = nokta2
        
        # İki nokta arasındaki doğruyu bulmak için iki nokta arasındaki eğimi hesaplayalım.
        if x2 - x1 == 0:  # Doğru y ekseni ile paraleldir.
            doğru_x_paralel += aynı_nokta_sayac
            print(f"Y eksenine paralel doğru: ({x1}, {y1}) - ({x2}, {y2})")
        elif y2 - y1 == 0:  # Doğru x ekseni ile paraleldir.
            doğru_y_paralel += aynı_nokta_sayac
            print(f"X eksenine paralel doğru: ({x1}, {y1}) - ({x2}, {y2})")
        
        # Aynı noktalardan geçen doğruları saymak için sayaç artırılır.
        if nokta1 == nokta2:
            aynı_nokta_sayac += 1

print(f"X eksenine paralel doğru sayısı: {doğru_y_paralel}")
print(f"Y eksenine paralel doğru sayısı: {doğru_x_paralel}")
