using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Models
{
    public class Seyahat
    {
        public int ID { get; set; }
        public int KullaniciId { get; set; }
        public string Nereden { get; set; }
        public string Nereye { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public int KoltukSayisi { get; set; }
        public bool Yayin { get; set; }
    }
}
