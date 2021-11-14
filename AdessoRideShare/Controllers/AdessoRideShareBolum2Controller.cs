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

        [HttpPost]
        public IActionResult SeyahatOlustur([FromBody] RSeyahatOlustur req)
        {
            Seyahat2 s = new Seyahat2();
            s.Nereden = req.Nereden;
            s.Nereye = req.Nereye;
            s.GuzergahOlustur();
            return Ok();
        }
    }
}
