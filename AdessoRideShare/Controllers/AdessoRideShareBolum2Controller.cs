using AdessoRideShare.Models;
using AdessoRideShare.Models.Bolum2;
using AdessoRideShare.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Controllers
{
    [ApiController]
    [Route("Bolum2/[action]")]
    public class AdessoRideShareBolum2Controller : ControllerBase
    {
        public static List<Seyahat2> seyahatlar = new();
        public static List<Kullanici> kullanicilar = new();
        public static List<SeyahatKatilim> seyahatKatilimlar = new();

        private int KullaniciOlustur()
        {
            var kullaniciCount = kullanicilar.Count;
            var kullanici = new Kullanici { ID = ++kullaniciCount };
            kullanicilar.Add(kullanici);
            return kullanici.ID;
        }

        [HttpPost]
        public IActionResult SeyahatOlustur([FromBody] Seyahat2 seyahat)
        {
            if (seyahat.Nereden < 0 || seyahat.Nereden > 199)
                return BadRequest("Sehirler 0 ila 199 arasında olabilir.");
            if (seyahat.Nereye < 0 || seyahat.Nereye > 199)
                return BadRequest("Sehirler 0 ila 199 arasında olabilir.");
            if (seyahat.KoltukSayisi < 1)
                return BadRequest("KoltukSayisi 1'den kucuk olamaz.");

            if (seyahat.KullaniciId == 0)
            {

                seyahat.KullaniciId = KullaniciOlustur();
            }
            else
            {
                var varOlanKullanici = kullanicilar.FirstOrDefault(x => x.ID == seyahat.KullaniciId);
                if (varOlanKullanici is null)
                    return BadRequest("Boyle bir kullanici bulunamadi. ID: " + seyahat.KullaniciId);
            }

            var seyahatCount = seyahatlar.Count;
            seyahat.ID = ++seyahatCount;
            seyahatlar.Add(seyahat);

            seyahat.GuzergahOlustur();
            seyahatlar.Add(seyahat);
            return Ok(seyahat);
        }

        // Kullanıcılar Nereden ve Nereye bilgileri ile seyahat aradığında bu güzergahtan geçen tüm yayında olan seyahat planlarını bulabilmeli
        [HttpGet]
        public IActionResult GuzergahBul ([FromQuery] int Nereden, [FromQuery] int Nereye)
        {
            var seyahatListesi = seyahatlar.Where(x =>  x.Yayin && x.GuzergahtakiSehirler.Contains(Nereden) && x.GuzergahtakiSehirler.Contains(Nereye)).ToList();
            return Ok(seyahatListesi);
        }
    }
}
