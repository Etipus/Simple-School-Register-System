using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okul_menu
{
    internal class Program
    {
        public static int sayac = 0;
        public static string[] adsoyad = new string[5];
        public static string[] numara = new string[5];
        public static int[] vize = new int[5];
        public static int[] final = new int[5];
        public static double[] ortalama = new double[5];
        static void Main(string[] args)
        {
            menuislemleri();
        }
        static void menuislemleri()
        {
            Console.WriteLine("------MENÜYE HOŞGELDİNİZ------\n1-KAYIT EKLE\n2-KAYIT LİSTELE\n3-KAYIT SİL\n4-KAYIT DÜZELT\n5-KAYIT ARAMA\n6-ÇIKIŞ");
            Console.Write("LUTFEN SEÇİMİNİZİ YAPINIZ(1-4):");
            char menusecim = Convert.ToChar(Console.ReadLine());
            if (menusecim != '1' && menusecim != '2' && menusecim != '3' && menusecim != '4' && menusecim != '5')
            {
                Console.Clear();
                menuislemleri();
            }
            switch (menusecim)
            {
                case '1':
                    kayıtekleme();       break;
                case '2':
                    kayıtliste();        break;
                case '3':
                    kayıtsil();          break;
                case '4':
                    kayıtduzelt();       break;
                case '5':
                    kayıtarama();        break;
                case '6':
                    Environment.Exit(0); break;
            }
        }
        static void kayıtekleme()
        {
            Console.Clear();
            Console.WriteLine("------KAYIT EKLEME İŞLEMLERİ------");
            Console.Write("Adı Soyadı:");
            adsoyad[sayac] = Console.ReadLine();
            Console.Write("Numara:");
            numara[sayac] = Console.ReadLine();
            Console.Write("Vize Notu:");
            vize[sayac] = Convert.ToInt16(Console.ReadLine());
            Console.Write("Final Notu:");
            final[sayac] = Convert.ToInt16(Console.ReadLine());
            ortalama[sayac] = (vize[sayac] * 0.4) + (final[sayac] * 0.6);
            Console.WriteLine("Ortalama:"+ortalama[sayac]);
            sayac ++;
            Console.Write("Başka bir kayıt eklemek için k menüişlemlerine dönmek için m ye çıkmak için herhangi bir tuşa basınız:");
            char eklemesecim = Convert.ToChar(Console.ReadLine());
            if (eklemesecim == 'k' || eklemesecim == 'K')
            {
                Console.Clear ();
                kayıtekleme();
            }
            else if (eklemesecim == 'm' || eklemesecim == 'M')
            {
                Console.Clear();
                menuislemleri();
            }
            else
                Environment.Exit(0);
        }
        static void kayıtliste()
        {
            Console.Clear();
            bool kayitkontrol = false;
            for (int i = 0; i < adsoyad.Length; i++)
            {
                if (adsoyad[i] != null)
                {
                    kayitkontrol = true;
                    Console.WriteLine("Adı Soyadı:{0} Numarası:{1} Vize Notu:{2} Final Notu:{3} Ortalaması:{4}", adsoyad[i], numara[i], vize[i], final[i], ortalama[i]);
                }
            }
            if(kayitkontrol == false)
            {
                Console.WriteLine("Kayıtlı Öğrenci Bulunamadı.");
            }
            Console.WriteLine("Menüişlerimlerine dönmek için herhangi bir tuşa basınız.");
            Console.ReadKey();
            Console.Clear();
            menuislemleri();
        }
        static void kayıtduzelt()
        {
            Console.Clear();
            Console.WriteLine("------KAYIT DÜZELTME İŞLEMLERİ------");
            Console.Write("KAYIT DÜZELTMEK İSTEDİĞİNİZ ÖĞRENCİ NUMARASI:");
            string ogrnumara = Console.ReadLine();
            int index = Array.IndexOf(numara, ogrnumara);
            if(index >= 0)
            {
                Console.WriteLine("ÖĞRENCİ BİLGİLERİ:");
                Console.WriteLine("ÖĞRENCİ NO:{0} ADI SOYADI:{1} VİZE NOTU:{2} FİNAL NOTU:{3} ORTALAMA:{4}",numara[index],adsoyad[index],vize[index],final[index],Math.Round(ortalama[index],0));
                Console.Write("ADI SOYADI:");   adsoyad[index] = Console.ReadLine();
                Console.Write("VİZE NOTU:");    vize[index] = Convert.ToInt16(Console.ReadLine());
                Console.Write("FİNAL NOTU:");   final[index] = Convert.ToInt16(Console.ReadLine()) ;
                ortalama[index] = (vize[index] * 0.4) + (final[index] * 0.6);
                Console.WriteLine("ORTALAMA:{0}",Math.Round(ortalama[index],0));
                Console.Write("BAŞKA BİR KAYIT DÜZENLEMEK İÇİN D VEYA d TUŞLAYINIZ");
                char duzeltsecim = Convert.ToChar(Console.ReadLine());
                if (duzeltsecim == 'D' || duzeltsecim == 'd')
                {
                    Console.Clear();
                    kayıtduzelt();
                }
                else
                    menuislemleri();
            }
            else
            {
                Console.WriteLine("{0} NUMARALI ÖĞRENCİ KAYITLI DEĞİLDİR!", ogrnumara);
                Console.Write("ANA MENÜYE DÖNMEK İÇİN BİR TUŞA BASINIZ.");
                Console.ReadKey();
                menuislemleri();
            }
        }
        static void kayıtsil()
        {
            Console.Clear();
            Console.WriteLine("------KAYIT SİLME İŞLEMLERİ------");
            Console.Write("KAYDINI SİLMEK İSTEDİĞİNİZ ÖĞRENCİNİN NUMARASI:");
            string ogrnumara = (Console.ReadLine());
            int index = Array.IndexOf(numara, ogrnumara);
            if(index >= 0)
            {
                Console.WriteLine("ÖĞRENCİ NO:{0} ADI SOYADI:{1} VİZE NOTU:{2} FİNAL NOTU:{3} ORTALAMA:{4}", numara[index], adsoyad[index], vize[index], final[index], Math.Round(ortalama[index], 0));
                Array.Clear(numara, index, 1);
                Array.Clear(adsoyad, index, 1);
                Array.Clear(vize, index, 1);
                Array.Clear(final, index, 1);
                Array.Clear(ortalama, index, 1);
                Console.Write("BAŞKA BİR KAYI SİLMEK İÇİN S VEYA s TUŞUNA BASINIZ");
                char silmesecim = Convert.ToChar(Console.ReadLine());
                if(silmesecim == 's' || silmesecim == 'S')
                {
                    Console.Clear() ;
                    kayıtsil();
                }
                else
                {
                    menuislemleri();
                }
            }
            else
            {
                Console.WriteLine("{0} NUMARALI ÖĞRENCİ KAYITLI DEĞİLDİR!", ogrnumara);
                Console.Write("ANA MENÜYE DÖNMEK İÇİN BİR TUŞA BASINIZ.");
                Console.ReadKey();
                menuislemleri();
            }
        }
        static void kayıtarama()
        {
            Console.Clear();
            Console.WriteLine("------KAYIT TARAMA İŞLEMLERİ------");
            Console.WriteLine("ARAMAK İSTEDİĞİNİZ ÖĞRENCİNİN NUMARASINI GİRİNİZ:");
            string ogrnumara = Console.ReadLine();
            int index = Array.IndexOf(numara, ogrnumara);
            if(index >= 0)
            {
                Console.WriteLine("ÖĞRENCİ NO:{0} ADI SOYADI:{1} VİZE NOTU:{2} FİNAL NOTU:{3} ORTALAMA:{4}", numara[index], adsoyad[index], vize[index], final[index], Math.Round(ortalama[index], 0));
                Console.Write("BAŞKA BİR ÖĞRENCİ ARAMAK İÇİN A VEYA a TUŞUNA BASINIZ:");
                char aramasecim = Convert.ToChar(Console.ReadLine());
                if(aramasecim == 'a' || aramasecim == 'A')
                {
                    Console.Clear();
                    kayıtarama();
                }
                else
                {
                    menuislemleri() ;
                }
            }
            else
            {
                Console.WriteLine("{0} NUMARALI ÖĞRENCİ KAYITLI DEĞİLDİR!", ogrnumara);
                Console.Write("ANA MENÜYE DÖNMEK İÇİN BİR TUŞA BASINIZ.");
                Console.ReadKey();
                menuislemleri();
            }
        }
    }
}
