using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class HES_kodu_kontrol_uyg
{
    static async Task Main(string[] args)
    {
        // Kontrol edilecek HES kodlarını tanımla
        List<string> hesKodlari = new List<string>
        {
            "G1B5-6449-15",
            "G5B2-3442-88"
        };

        // Bir HTTP istemcisi oluştur
        using var httpClient = new HttpClient();

        // API uç noktası URL'sini tanımla (gerçek URL değil)
        string apiUrl = "https://api.saglikbakanligi.gov.tr/HES/dogrula";

        // Sonuçları saklamak için bir liste oluştur
        List<HesDogrulamaSonucu> sonuclar = new List<HesDogrulamaSonucu>();

        foreach (var hesKodu in hesKodlari)
        {
            // İstek verisini hazırla
            var istekVerisi = new
            {
                hes = hesKodu
            };

            // İstek verisini JSON olarak serileştir
            var jsonIstekVerisi = JsonSerializer.Serialize(istekVerisi);

            // İstek için JSON içeriği oluştur
            var icerik = new StringContent(jsonIstekVerisi, Encoding.UTF8, "application/json");

            // API'ye POST isteği gönder
            var yanit = await httpClient.PostAsync(apiUrl, icerik);

            if (yanit.IsSuccessStatusCode)
            {
                // Yanıt JSON'unu ayrıştır
                var jsonYanit = await yanit.Content.ReadAsStringAsync();
                var dogrulamaSonucu = JsonSerializer.Deserialize<HesDogrulamaSonucu>(jsonYanit);

                sonuclar.Add(dogrulamaSonucu);
            }
            else
            {
                // Hata durumunu işle
                Console.WriteLine($"HES kodu {hesKodu} doğrulama başarısız oldu. Durum kodu: {yanit.StatusCode}");
            }
        }

        // Sonuçları riskli ve risksiz kategorilere ayır
        var riskliKodlar = sonuclar.Where(r => r.Durum == "risky").ToList();
        var risksizKodlar = sonuclar.Where(r => r.Durum == "riskless").ToList();

        // Sonuçları görüntüle
        Console.WriteLine("Riskli HES Kodları:");
        foreach (var kod in riskliKodlar)
        {
            Console.WriteLine($"HES: {kod.Hes}, Durum: {kod.Durum}");
        }

        Console.WriteLine("\nRisksiz HES Kodları:");
        foreach (var kod in risksizKodlar)
        {
            Console.WriteLine($"HES: {kod.Hes}, Durum: {kod.Durum}");
        }
    }
}

// API yanıtını temsil edecek bir sınıfı tanımla
public class HesDogrulamaSonucu
{
    public string Hes { get; set; }
    public string Durum { get; set; }
}

