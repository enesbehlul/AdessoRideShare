using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Models.Bolum2
{
    public class Seyahat2
    {
        public int ID { get; set; }
        public int KullaniciId { get; set; }
        public int Nereden { get; set; }
        public int Nereye { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public int KoltukSayisi { get; set; }
        public bool Yayin { get; set; }
        public List<int> GuzergahtakiSehirler { get; set; } = new List<int>();

        public void GuzergahOlustur()
        {
            int yon = 0;

            var modNereden = Nereden % 20;
            var modNereye = Nereye % 20;
            var modFark = modNereden - modNereye; // sag ya da sol yon tayini

            if (modNereden > modNereye)
                yon += (int)Yonler.Sol;
            else if (modNereden < modNereye)
                yon += (int)Yonler.Sag;


            var yukseklikNereden = Nereden / 20;
            var yukseklikNereye = Nereye / 20;

            var yukseklikFark = Math.Abs(yukseklikNereden - yukseklikNereye);

            if (yukseklikNereden > yukseklikNereye)
                yon += (int)Yonler.Yukari;
            else if (yukseklikNereden > yukseklikNereye)
                yon += (int)Yonler.Asagi;


            switch (yon)
            {
                case (int)Yonler.Yukari:
                    for (int i = Nereden; i < Nereye; i = i - 20)
                    {

                    }
                    break;
                case (int)Yonler.Asagi:
                    break;
                case (int)Yonler.Sol:
                    break;
                case (int)Yonler.Sag:
                    break;
                case (int)Yonler.YukariSag:
                    break;
                case (int)Yonler.YukariSol:
                    break;
                case (int)Yonler.AsagiSag:
                    break;
                case (int)Yonler.AsagiSol:
                    break;
                default:
                    break;
            }

        }
    }

    public enum Yonler
    {
        Yukari = 2,
        Asagi = 4,
        Sag = 8,
        Sol = 16,
        YukariSag = 10,
        YukariSol = 18,
        AsagiSag = 12,
        AsagiSol = 20
    }
}
