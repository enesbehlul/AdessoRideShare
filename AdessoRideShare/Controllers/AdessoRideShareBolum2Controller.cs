using AdessoRideShare.Models;
using AdessoRideShare.Models.Bolum2;
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
        public IActionResult SeyahatOlustur()
        {
            return Ok();
        }
    }
}
