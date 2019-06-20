using System;

namespace Oop_t16_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates");

            Console.WriteLine("---------------");

            #region 1-Delegates Giriş
            Console.WriteLine("1-Delegates Giriş");
            CustumerManagerF1 custumerManagerF1 = new CustumerManagerF1();
            //custumerManagerF1.SendMessage();
            //custumerManagerF1.ShowAlert();

            //1. Adım : Elçimize Selam Ver Komutunu Ekledik
            //2. Adım : Elçimize Hal ve Hareketlerine Dikkat Etmesini Söyledik.

            MyDelegateV1 myDeleteV1 = custumerManagerF1.SendMessageF1;
            myDeleteV1 += custumerManagerF1.ShowAlertF1;

            //3. Adım : Elçimize Selam Komutu Sildik
            myDeleteV1 -= custumerManagerF1.SendMessageF1;
            myDeleteV1();


            //Parametreli Delegate
            MyDelegateV2 myDelegateV2 = custumerManagerF1.SendMessageF2;
            myDelegateV2 += custumerManagerF1.ShowAlertF2;
            myDelegateV2("Hello");

            MathsF1 mathsF1 = new MathsF1();

            MyDelegateV3 myDelegateV3 = mathsF1.Gather;
            myDelegateV3 += mathsF1.Multiply;
            var result = myDelegateV3(4, 5);

            //En Son Çalışan Delegate Referans Alarak Sonuç Döndündür. Bu Örnek'te Gather Bir Anlamı Yoktur.
            Console.WriteLine(result);
            #endregion

            Console.WriteLine("---------------");


            #region 2-Action İle Çalışmak
            Console.WriteLine("2-Action İle Çalışmak");
            //Farklı Bir Metoda Parametresiz Metod Gönderme
            HandleMetods(() =>
            {
                Find();
            });
            #endregion

            Console.WriteLine("---------------");


            #region 3-Func ile Çalışmak
            Console.WriteLine("3-Func ile Çalışmak");

            Func<int, int, int> add = Topla;
            Console.WriteLine(add(3, 5));


            //İlk Yazım
            Func<int> getRandomNumberF1 = delegate ()
            {
                Random random = new Random();
                return random.Next(2, 100);
            };

            Console.WriteLine(getRandomNumberF1());

            //İkinci Yazım
            //=()=> Bu Bir Delegasyonu İfade Eder.
            Func<int> getRandomNumberF2 = () => new Random().Next(1, 100);
            Console.WriteLine(getRandomNumberF2());

            #endregion

            Console.ReadLine();
        }

        #region 2-Action İle Çalışmak
        private static void HandleMetods(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                Console.Write("Hata Mesajı " + e);
            }
        }
        private static void Find()
        {
            Console.WriteLine("Arama Yapıldı");
        }

        #endregion

        #region 3-Func ile Çalışmak
        //Action  ile Func Birer Delegedir.
        //Action Void Türünde Özel bir Tür Döndürmeyen Delegasyon İşlemlerdir. //Metod ve Kod BLokları için Kullanılır.
        //Funs İse buna Ek olarak Dönüş Tipi Olan Delegasyonlardır. MEtodların Yönetimi İçin Kullanılır.

        static int Topla(int numberF1, int numberF2)
        {
            return numberF1 + numberF2;
        }
        #endregion
    }

    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 27 (Delegates) ===> Ders 111
    /// </summary>
    //Delegates
    // 1=£ Delegates Giriş
    // 2=£ Action İle Çalışmak
    // 3=£ Func ile Çalışmak

    #region 1-Delegates Giriş
    //Delegate'ler Yazılım'da Elçi Görevlerini Üstlenirler.
    //Yazılım Süreçlerinde Birbirleri İle Haberleşme Görevlerini Üstlenirler.
    public delegate void MyDelegateV1(); //Elçiyi Tanımladık
    public delegate void MyDelegateV2(string text);
    public delegate int MyDelegateV3(int numberF1, int numberF2);
    public class CustumerManagerF1
    {
        public void SendMessageF1()
        {
            Console.WriteLine("Hello !");
        }
        public void ShowAlertF1()
        {
            Console.WriteLine("Be Careful !");
        }

        public void SendMessageF2(string message)
        {
            Console.WriteLine(message);
        }
        public void ShowAlertF2(string alert)
        {
            Console.WriteLine(alert);
        }
    }
    public class MathsF1
    {
        public int Gather(int numberF1, int numberF2)
        {
            return numberF1 + numberF2;
        }
        public int Multiply(int numberF1, int numberF2)
        {
            return numberF1 * numberF2;
        }
    }

    #endregion

    #region 2-Action İle Çalışmak
    //Dont repeat your self == ' Kendini Tekrarlama
    //Loglama, Hata Yatalama, Validation, Gibi Aksiyonlar Action'lar ile Yapılmaktadır.

    #endregion

    #region 3-Func ile Çalışmak
    //Action  ile Func Birer Delegedir.
    //Action Void Türünde Özel bir Tür Döndürmeyen Delegasyon İşlemlerdir. //Metod ve Kod BLokları için Kullanılır.
    //Funs İse buna Ek olarak Dönüş Tipi Olan Delegasyonlardır. MEtodların Yönetimi İçin Kullanılır.
    #endregion
}
