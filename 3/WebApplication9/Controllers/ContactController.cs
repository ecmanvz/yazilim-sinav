using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(Contact model)
        {
            if (ModelState.IsValid)
            {
                // Verileri işle

                return Content("Mesajınız başarıyla gönderildi!");
            }

            // Veri doğrulama hatası varsa, hata mesajlarını JSON olarak dön
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Content(string.Join("<br>", errors));
        }
    }
}
