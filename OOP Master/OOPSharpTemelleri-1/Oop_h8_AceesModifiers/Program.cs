using System;

namespace Oop_h8_AceesModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Access Modifiers");

            Console.WriteLine("----------------------");

            #region 1- Private & Protected

            #endregion

            Console.WriteLine("----------------------");

            #region 2- Internal

            #endregion

            Console.WriteLine("----------------------");

            #region 3- Public

            #endregion

            Console.ReadLine();

        }
    }

    /// <summary>
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 16 (Access Modifiers) ===> Ders 71
    /// </summary>
    //Access Modifiers
    // 1=£ Private & Protected
    // 2=£ Internal
    // 3=£ Public

    #region 1- Private & Protected
    //Private Bir değişken Sadece Tanımlandığı Blok'da (Scope İçerisinde -- Kapsam'da) İçerisinde Geçerlidir.

    //Protected private'nin tüm özelliklerini kapsar.
    //Protected class seviyesinde tanımlanır.
    //Ayrıca protected inherit edildiği sınıflarda kullanılır.
    #endregion
    #region 2- Internal
    //Classların default access modifiers'ları internal'dır.
    //Üst seviye bir Class private ve protected olamaz. (Farklı bir class tarafından miras alınma işlemine üst seviye class denir)
    //İç içe Class'larda private yada protected tanımlanabilir. 
    //internal bağlı bulunduğu proje içerisinden Örneğin ==> Oop8AceesModifiers içerisinden herhangi bir assembly'den referans ihtiyacı olmadan ulaşılabilinir.

    #endregion
    #region 3- Public
    //Public referans verilen her yede kullanılablir. Örneğin Oop1Metodlar kullamak istediğim istediğim özelliği public yapıp using .... işlemleri ile kullanabilirim.
    //Bir şeyin neye ihtiyacı varsa one göre tanımlama yapmalısın ! List privilich == Makale Yaz
    #endregion
}
