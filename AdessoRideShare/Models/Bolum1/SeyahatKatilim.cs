using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Models
{
    public class SeyahatKatilim
    {
        public int ID { get; set; }
        public int SeyehatId { get; set; }
        public int KullaniciId { get; set; }
    }
}
