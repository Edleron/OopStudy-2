using System;

namespace Oop_j10_DegerVeReferansTipler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Değer ve Referans Tipler -- Referance And Value Type");
            #region 1-Değer ve Referans Tipler
            Console.WriteLine("1-Değer ve Referans");
            #endregion
        }
    }

    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 18 (Değer ve Referans Tipler) ===> Ders 79
    /// </summary>
    //Referances And Value
    // 1=£ Değer ve Referans

    #region 1-Değer ve Referans
    //İnteger, Boolean, Double, Decimal ==> Bunlar Değer Tiplidir.
    //Class'lar, String, Interface, Abstract, Arrayler Classlar ==> Bunlar'da Referans Tiplidir.

    //Değer Tipler'de olay tamamen değeri üzerindne ele alınır.

    //Referanslar tiplerde ise 
    //string [] cities1 = new string[] {"Ankara","Bursa",Afyon};
    //Referans tipli keywordler, new'lendiğinde yani instance alındığında bellek'te iki adet yer tutulur.
    //1.'si Değişkenin kendi ismi == "cities1"
    //2.'si Değişkenin içersindeki Değerler == "Ankara","Bursa","Afyon"

    //Olay tamamen bellek üzerinden ilerler.

    ///1.Adım
    //string [] cities1 = new string[] {"Ankara","Adana",Afyon};
    //string [] cities2 = new string[] {"Bursa","Balıkeisr",Bolu};

    ///2.Adım
    //string [] cities1 = new string[] {"Ankara","Adana",Afyon};  ============ 101 >>>> Bellek Referans Numarası
    //string [] cities2 = new string[] {"Bursa","Balıkeisr",Bolu};============ 102 >>>> Bellek Referans Numarası

    ///3.Adım
    //cities2 = cities1;       

    ///4.Adım
    //Cities1' atama işlemi yaptığımdan bellek referans numaraları eşitlenir.
    //cities1 = {"Ankara","Adana",Afyon};  ============ 101 >>>> Bellek Referans Numarası
    //cities2 = {"Ankara","Adana",Afyon};  ============ 101 >>>> Bellek Referans Numarası

    ///5.Adım
    //cities1[0] = "İstanbul";

    ///6.Adım
    //cities1 = {"İstanbul","Adana",Afyon};
    //cities2 = {"İstanbul","Adana",Afyon};

    ///7.Adım
    //Garbage Collector == Devreye girer (Çöp Toplayıcı)
    //Tutulmayan bir nesne olduğunda onu bellekten temizler.
    //Bunun Yönetimi .Net & C#'tadır.
    #endregion
}
