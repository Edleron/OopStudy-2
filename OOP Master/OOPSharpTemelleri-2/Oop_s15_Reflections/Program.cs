using System;
using System.Reflection;

namespace Oop_s15_Reflections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reflections");

            Console.WriteLine("--------------");

            #region 1-Reflections Giriş
            Console.WriteLine("1-Reflections Giriş");
            DortIslemF1 dortIslemF1 = new DortIslemF1(2, 3);
            Console.WriteLine(dortIslemF1.ToplaF2());
            Console.WriteLine(dortIslemF1.ToplaF1(4, 4));

            var typeF1 = typeof(DortIslemF1);
            DortIslemF1 dortIslemF2 = (DortIslemF1)Activator.CreateInstance(typeF1, 6, 7);
            Console.WriteLine(dortIslemF2.ToplaF2());
            #endregion

            Console.WriteLine("--------------");

            #region 2-Reflections Invoke
            Console.WriteLine("2-Reflections Invoke");
            var typeF2 = typeof(DortIslemF1);
            var instance = Activator.CreateInstance(typeF2, 1, 2);
            //Console.WriteLine(instance.GetType().GetMethod("ToplaF2").Invoke(instance, null));
            MethodInfo methodInfo = instance.GetType().GetMethod("ToplaF2"); // Metod bilgisi Toplama
            Console.WriteLine(methodInfo.Invoke(instance, null)); //İnstance ile bağlantıyı sağladık

            #endregion

            Console.WriteLine("--------------");

            #region 3-Reflections Detayları
            Console.WriteLine("3-Reflections Detayları");
            //Reflections'lara Liste Şeklinde Ulaşmak
            var typeF3 = typeof(DortIslemF1);
            var methods = typeF3.GetMethods();
            foreach (var info in methods)
            {
                Console.WriteLine("Metod Adı : {0}", info.Name);
                //Parametlerine Reflections ile ulaşmak
                foreach (var parameters in info.GetParameters())
                {
                    Console.WriteLine("Parameters : {0}", parameters.Name);
                }
                foreach (var attiribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attiribute : {0}", attiribute.GetType().Name);
                }

            }
            #endregion

            Console.ReadLine();
        }
    }


    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 26 (Reflections) ===> Ders 108
    /// </summary>
    //Reflections
    // 1=£ Reflections Giriş
    // 2=£ Reflections Invoke
    // 3=£ Reflections Detayları

    #region 1-Reflections Giriş
    //Reflections Uygulama Çalıştığı Anda Hakkında Bilgi Toplayabilir
    //Hatta Toplağımız Bilgiye Göre İstediğimiz Zaman Bir Metodu Çalıştırabiliriz.
    //Çalışma Anından Kasıntı Kullancı Ekranlarında Yapmak İstediklerimize Karşılık Cevap Veren Önemli Özelliklerden Bir Tanesidir.
    //Örneğin Çalışma Anında Bir Nesnenin Örneği Oluşturup Onu Çalıştırabiliriz.

    //Buna Neden İhtiyaç Duyuyoruz Çünkü Biz Çalışma anında Hangi Nesne ile Çalışacağımızı Bİlmiyoruz.
    //Kullanıcın Girdiği Değerlere göre Karar verdiren Yapıların Yazılmasına Yarar.
    //Yani Bri kullanıcı için Hangi Nesnenin, Hangi Metodun Çalıştıralacağına Uygulamadaki Gidişata Göre Karar Verdiriyoruz.

    //Bir Diper Özellliği İse Çalışma Anında Nesnelerden Bilgi Almaktır.

    public class DortIslemF1
    {
        private int _numberF1;
        private int _numberF2;
        public DortIslemF1(int NumberF1, int NumberF2)
        {
            _numberF1 = NumberF1;
            _numberF2 = NumberF2;
        }

        public int ToplaF1(int NumberF1, int NumberF2)
        {
            return NumberF1 + NumberF2;
        }

        public int CarpF1(int NumberF1, int NumberF2)
        {
            return NumberF1 * NumberF2;
        }

        public int ToplaF2()
        {
            return _numberF1 + _numberF2;
        }

        [MetodName("Carpma İslemi")]
        public int CarpF2()
        {
            return _numberF1 * _numberF2;
        }
    }
    #endregion

    #region 2-Reflections Invoke

    #endregion

    #region 3-Reflections Detayları
    public class MetodNameAttribute : Attribute
    {
        public MetodNameAttribute(string name)
        {

        }
    }
    #endregion
}
