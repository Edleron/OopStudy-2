using System;
using System.Linq;

namespace Oop_a1_Metodlar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Metotlar Konu Anlatımı");

            Console.WriteLine("----------------------");

            #region 4-Ref Out Keyword
            Console.WriteLine("4-Ref Out Keyword");
            int numberF4a1 = 20;
            int numberF4a2 = 100;

            var resultF4a1 = AddF4A1(numberF4a1, numberF4a2);
            Console.WriteLine("Ref Out Olmayan Değişken Sonucu. : " + numberF4a1);
            Console.WriteLine("Ref Out Olmayan Çıktı Sonucu. : " + resultF4a1);

            var resultF4a2 = AddF4A2(ref numberF4a1, numberF4a2);
            Console.WriteLine("Ref Değişken Sonucu. : " + numberF4a1);
            Console.WriteLine("Ref Çıktı Sonucu. : " + resultF4a2);

            int numberF4a3;
            var resultF4a3 = AddF4A3(out numberF4a3, numberF4a2);
            Console.WriteLine("Out Değişken Sonucu. : " + numberF4a3);
            Console.WriteLine("Out Çıktı Sonucu. : " + resultF4a3);
            #endregion

            Console.WriteLine("----------------------");

            #region 6-Params
            Console.WriteLine("Params");
            Console.WriteLine(AddF6A1(2, 4, 5, 6));
            Console.WriteLine(AddF6A2(2, 4, 5, 6));
            #endregion

            Console.ReadLine();

        }

        /// <summary>
        ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 6 (Metotlar) ===> Ders 41
        /// </summary>
        //Metodlar
        // 1=£ Static Metodlar & Void Metodlar
        // 2=£ Parametreli Metodlar (Return) => Geriye Değer Döndüren
        // 3=£ Default Parametreli Metodlar 
        // 4=£ Ref Out Keyword
        // 5=£ Method Overloading
        // 5=£ Params

        #region 1-Static Metodlar & Void Metodlar
        //Static Metodlar İntance almadan kullanılabilirler.
        //Void metodlar geriye boş değer döndürürler.
        static void AddF1A1()
        {
            Console.WriteLine("Added !!!");
        }
        #endregion




        #region 2-Parametreli Metodlar & Return
        static void AddF2A1(int numberF2a1, int numberF2a2)
        {
            int result = numberF2a1 + numberF2a2;
        }
        static int AddF2A2(int numberF2a1, int numberF2a2)
        {
            return numberF2a1 + numberF2a2;
        }
        #endregion




        #region 3-Default Parametreli Metotlar
        //Metodların En Sonunda Tanımlanmaları Gerekir
        static int AddF3A1(int numberF3a1, int numberF3a2 = 30)
        {
            return numberF3a1 + numberF3a2;
        }
        #endregion




        #region 4-Ref Out Keyword       
        //Ref (Değer Tipli Değişkenler Her Zaman Değiştirilemez)
        //Değer Tipler'le Çalışıldığı için Sonuç Değişmez numberF4a1 Değeri Hep 20 Olarak Kalır
        static int AddF4A1(int numberF4a1, int numberF4a2)
        {
            numberF4a1 = 30;
            return numberF4a1 + numberF4a2;
        }

        //Ref == Referans Tipli Bir parametre istediğimizde Değişkenimizin referansını çağırdımız içim Değeri'de değişecektir.
        //Ref Keyword'unde Değişkenimizin muhakkan değeri başlangıçta atanmış olmalıdır.
        //int numberF4a1 = 20;
        static int AddF4A2(ref int numberF4a1, int numberF4a2)
        {
            numberF4a1 = 30;
            return numberF4a1 + numberF4a2;
        }

        //Out == Referans Tipli Bir parametre istediğimizde Değişkenimizin referansını çağırdımız içim Değeri'de değişecektir.
        //Out Keyword'unde Değişkenimizin muhakkan değeri başlangıçta atanmış olmasına Gerek Yoktur.
        //int numberF4a3;
        static int AddF4A3(out int numberF4a3, int numberF4a2)
        {
            numberF4a3 = 30;
            return numberF4a3 + numberF4a2;
        }
        #endregion




        #region 5-Method Overloading
        static int AddF5A1(int numberF4a1, int numberF4a2)
        {
            return numberF4a1 * numberF4a2;
        }

        static int AddF5A1(int numberF4a1, int numberF4a2, int numberF4a3)
        {
            return numberF4a1 * numberF4a2 * numberF4a3;
        }
        #endregion




        #region 6-Params
        static int AddF6A1(params int[] numbers)
        {
            return numbers.Sum();
        }

        //Param harici parametler params keyword'unden önce gelmek zorundadir.
        static int AddF6A2(int number, params int[] numbers)
        {
            return numbers.Sum();
        }
        #endregion
    }
}
