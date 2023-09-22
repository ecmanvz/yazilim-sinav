using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication10.Models;

public class UserController : Controller
{
    public async Task<IActionResult> Index()
    {
        // API'den verileri çekmek için HttpClient kullanımı
        using (var httpClient = new HttpClient())
        {
            try
            {
                // API'nin adresi
                string apiUrl = "https://gorest.co.in/public/v2/users";

                // GET isteği gönder ve yanıtı al
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Yanıtı JSON olarak oku
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // JSON verilerini C# nesnelerine dönüştürme
                    var users = JsonConvert.DeserializeObject<List<User>>(responseBody);

                    // Model'i View'e aktar ve görüntülemeyi çağır
                    return View(users);
                }
                else
                {
                    ViewBag.ErrorMessage = $"API'den veriler çekilirken bir hata oluştu: {response.StatusCode}";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Bir hata oluştu: {ex.Message}";
                return View("Error");
            }
        }
    }
}
