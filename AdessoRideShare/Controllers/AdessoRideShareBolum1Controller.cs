using AdessoRideShare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class AdessoRideShareBolum1Controller : ControllerBase
    {
        public static List<Kullanici> kullanicilar = new();
        public static List<Seyahat> seyahatlar = new();
        public static List<SeyahatKatilim> seyahatKatilimlar = new();

        private int KullaniciOlustur()
        {
            var kullaniciCount = kullanicilar.Count;
            var kullanici = new Kullanici { ID = ++kullaniciCount };
            kullanicilar.Add(kullanici);
            return kullanici.ID;
        }

        [HttpPost]
        public IActionResult SeyahatOlustur([FromBody] Seyahat seyahat)
        {
            if (seyahat.KoltukSayisi < 1)
                return BadRequest("KoltukSayisi 1'den kucuk olamaz.");
            if (string.IsNullOrEmpty(seyahat.Nereden))
                return BadRequest("Nereden bos olamaz.");
            if (string.IsNullOrEmpty(seyahat.Nereye))
                return BadRequest("Nereye bos olamaz.");

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

            return Ok(seyahat);
        }

        [HttpPut]
        public IActionResult SeyahatYayinGuncelle([FromBody] RSeyahatYayinGuncelle req)
        {
            var seyahatId = req.SeyahatId;

            var seyahat = seyahatlar.FirstOrDefault(x => x.ID == seyahatId);
            if (seyahat is null)
                return BadRequest("Boyle bir seyahat bulunamadi. ID: " + seyahatId);
            seyahat.Yayin = req.Yayin;

            return Ok();
        }

        [HttpGet]
        public IActionResult SeyahatAra([FromQuery] string Nereden, [FromQuery] string Nereye)
        {
            var NeredenExist = !string.IsNullOrEmpty(Nereden);
            var NereyeExist = !string.IsNullOrEmpty(Nereye);

            if (!NeredenExist && !NereyeExist)
                return BadRequest("Gecersiz istek parametreleri.");

            var sonuc =
            seyahatlar.Where(x => x.Yayin &&
                                    (!NeredenExist || x.Nereden.ToLower().Contains(Nereden.ToLower())) &&
                                    (!NereyeExist || x.Nereye.ToLower().Contains(Nereye.ToLower()))).ToList();

            return Ok(sonuc);
        }

        [HttpPost]
        public IActionResult SeyahataKatil([FromBody] RSeyahataKatil req)
        {
            var seyahatId = req.SeyahatId;
            var kullaniciId = req.KullaniciId;

            var seyahat = seyahatlar.FirstOrDefault(x => x.ID == seyahatId && x.Yayin);
            if (seyahat is null)
                return BadRequest("Boyle bir seyahat bulunamadi. ID: " + seyahatId);

            if (kullaniciId == 0)
                kullaniciId = KullaniciOlustur();
            else
            {
                var isKullaniciExist = kullanicilar.Any(x => x.ID == kullaniciId);
                if (!isKullaniciExist)
                    return BadRequest("Boyle bir kullanici bulunamadi. ID: " + kullaniciId);
                if (seyahat.KullaniciId == kullaniciId)
                    return BadRequest("Size ait olan seyahate katilimci olamazsiniz.");
            }

            var varOlanKatilimlar = seyahatKatilimlar.Where(x => x.SeyehatId == seyahatId).ToList();
            if (varOlanKatilimlar.Any(x => x.KullaniciId == kullaniciId))
                return Ok("Bu seyahate zaten kayitlisiniz.");

            var doluKoltukSayisi = varOlanKatilimlar.Count;
            if (seyahat.KoltukSayisi == doluKoltukSayisi)
                return BadRequest("Bu seyahatteki tum koltuklar dolu.");

            var seyahatKatilimSayisi = seyahatKatilimlar.Count;
            var seyahatKatilim = new SeyahatKatilim
            {
                ID = ++seyahatKatilimSayisi,
                KullaniciId = kullaniciId,
                SeyehatId = seyahatId
            };

            seyahatKatilimlar.Add(seyahatKatilim);

            return Ok(seyahatKatilim);

        }
    }
}
