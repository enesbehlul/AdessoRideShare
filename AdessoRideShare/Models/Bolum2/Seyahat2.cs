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
            int k = 0;

            int yon = 0;

            var modNereden = Nereden % 20;
            var modNereye = Nereye % 20;

            if (modNereden > modNereye)
                yon += (int)Yonler.Sol;
            else if (modNereden < modNereye)
                yon += (int)Yonler.Sag;


            var yukseklikNereden = Nereden / 20;
            var yukseklikNereye = Nereye / 20;

            if (yukseklikNereden > yukseklikNereye)
                yon += (int)Yonler.Yukari;
            else if (yukseklikNereden < yukseklikNereye)
                yon += (int)Yonler.Asagi;

            var komsularKumesi = new HashSet<int>();

            switch (yon)
            {
                case (int)Yonler.Yukari:
                    
                    for (int i = Nereden; i >= Nereye; i = i - 20)
                    {
                        komsularKumesi.Add(i);

                        var iMod = i % 20;
                        if (iMod - 1 >= 0)
                            komsularKumesi.Add(i - 1);
                        if (iMod + 1 <= 19)
                            komsularKumesi.Add(i + 1);
                    }
                    break;

                case (int)Yonler.Asagi:
                    for (int i = Nereden; i <= Nereye; i = i + 20)
                    {
                        komsularKumesi.Add(i);

                        var iMod = i % 20;
                        if (iMod - 1 >= 0)
                            komsularKumesi.Add(i - 1);
                        if (iMod + 1 <= 19)
                            komsularKumesi.Add(i + 1);
                    }
                    break;

                case (int)Yonler.Sol:
                    for (int i = Nereden; i >= Nereye; i--)
                    {
                        komsularKumesi.Add(i);

                        if (i - 20 >= 0)
                            komsularKumesi.Add(i - 20);
                        if (i + 20 <= 199)
                            komsularKumesi.Add(i + 20);
                    }
                    break;
                case (int)Yonler.Sag:
                    for (int i = Nereden; i <= Nereye; i++)
                    {
                        komsularKumesi.Add(i);

                        if (i - 20 >= 0)
                            komsularKumesi.Add(i - 20);
                        if (i + 20 <= 199)
                            komsularKumesi.Add(i + 20);
                    }
                    break;
                case (int)Yonler.YukariSag:
                    for (k = Nereden; k >= Nereye - modNereye; k = k - 19)
                    {
                        komsularKumesi.Add(k);
                        var kMod = k % 20;
                        if (kMod - 1 >= 0)
                            komsularKumesi.Add(k - 1);
                        if (kMod + 1 <= 19)
                            komsularKumesi.Add(k + 1);
                    }

                    for (int j = k + 19; j <= Nereye; j++)
                    {
                        komsularKumesi.Add(j);
                        if (j - 20 >= 0)
                            komsularKumesi.Add(j - 20);
                        if (j + 20 <= 199)
                            komsularKumesi.Add(j + 20);
                    }
                    break;
                case (int)Yonler.YukariSol:
                    for (k = Nereden; k >= Nereye - modNereye; k = k - 21)
                    {
                        komsularKumesi.Add(k);
                        var iMod = k % 20;
                        if (iMod - 1 >= 0)
                            komsularKumesi.Add(k - 1);
                        if (iMod + 1 <= 19)
                            komsularKumesi.Add(k + 1);
                    }

                    for (int j = k + 21; j >= Nereye; j--)
                    {
                        komsularKumesi.Add(j);
                        if (j - 20 >= 0)
                            komsularKumesi.Add(j - 20);
                        if (j + 20 <= 199)
                            komsularKumesi.Add(j + 20);
                    }
                    break;
                case (int)Yonler.AsagiSag:
                    for (k = Nereden; k < Nereye; k = k+21)
                    {
                        komsularKumesi.Add(k);

                        if (k - 20 >= 0)
                            komsularKumesi.Add(k - 20);
                        if (k + 20 <= 199)
                            komsularKumesi.Add(k + 20);
                    }

                    for (int j = k - 21; j <= Nereye; j++)
                    {
                        komsularKumesi.Add(j);
                        if (j - 1 >= 0)
                            komsularKumesi.Add(j - 1);
                        if (j + 1 <= 19)
                            komsularKumesi.Add(j + 1);
                    }
                    break;
                case (int)Yonler.AsagiSol:

                    for (k = Nereden; k < Nereye; k = k + 19)
                    {
                        komsularKumesi.Add(k);

                        if (k - 20 >= 0)
                            komsularKumesi.Add(k - 20);
                        if (k + 20 <= 199)
                            komsularKumesi.Add(k + 20);
                    }

                    for (int j = k; j >= Nereye; j--)
                    {
                        komsularKumesi.Add(j);
                        if (j - 1 >= 0)
                            komsularKumesi.Add(j - 1);
                        if (j + 1 <= 19)
                            komsularKumesi.Add(j + 1);
                    }
                    break;
                default:
                    break;
            }

            GuzergahtakiSehirler = komsularKumesi.ToList();
            //komsularKumesi.ToList().Sort();
            //var asas = 0;
            //var xx = komsularKumesi.ToList();
            //xx.Sort();
            //var xxx = 0;

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
