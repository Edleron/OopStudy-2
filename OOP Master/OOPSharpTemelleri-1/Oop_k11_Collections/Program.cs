using System;
using System.Collections;
using System.Collections.Generic;

namespace Oop_k11_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Collections");

            Console.WriteLine("----------------------");

            #region 1-Collections Giriş
            Console.WriteLine("1-Collections Girişleri");
            CityV1 cityV1 = new CityV1();
            cityV1.Add();
            #endregion

            Console.WriteLine("----------------------");

            #region 2-Array List
            Console.WriteLine("2-Array List");
            CityV2 cityV2 = new CityV2();
            cityV2.Add();
            #endregion

            Console.WriteLine("----------------------");

            #region 3-TipGüvenliği
            Console.WriteLine("3-TipGüvenliği");
            //İlk Kullanım
            List<CustomerV3> customerV3A1 = new List<CustomerV3>();
            customerV3A1.Add(new CustomerV3 { Id = 1, FirstName = "Ertuğrul" });
            customerV3A1.Add(new CustomerV3 { Id = 1, FirstName = "Gülnur" });
            foreach (var item in customerV3A1)
            {
                Console.WriteLine(item.FirstName);
            }
            //ikinci Kullanım
            List<CustomerV3> customerV3A2 = new List<CustomerV3>
            {
               new CustomerV3{Id = 1, FirstName="Şiir"},
               new CustomerV3{Id = 2, FirstName="Şura"}
            };
            foreach (var item in customerV3A2)
            {
                Console.WriteLine(item.FirstName);
            }
            #endregion

            Console.WriteLine("----------------------");

            #region 5-Dictionary
            Console.WriteLine("5-Dictionary");
            Dictionary<string, string> dictionaryV5 = new Dictionary<string, string>();
            dictionaryV5.Add("Book", "Kitap");
            dictionaryV5.Add("Table", "Tablo");

            Console.WriteLine(dictionaryV5["Table"]);

            foreach (var item in dictionaryV5)
            {
                Console.WriteLine("Anahtar- " + item.Key);

                Console.WriteLine("Değer- " + item.Value);
            }

            Console.WriteLine(dictionaryV5.ContainsKey("Book"));
            #endregion

            Console.WriteLine("----------------------");

            Console.ReadLine();
        }
    }


    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 19 (Collections) ===> Ders 80
    /// </summary>
    //Collections
    // 1=£ Collections Giriş
    // 2=£ Array List
    // 3=£ Tip Güvenliği Koleksiyonlar ile Çalışmak

    #region 1-Collections Giriş
    //Diziler New'lendiği için yeni instance üretilir iken, yeni value'ler eklenmeleri sorun yaratır.
    //Güncel projelerde Array'ler kullanılmaz.
    class CityV1
    {
        public void Add()
        {
            string[] cities = new string[2] { "Ankara", "İstanbul" };
            cities = new string[3];
            Console.WriteLine(cities[1]);
        }
    }
    #endregion

    #region 2-Array List
    class CityV2
    {
        public void Add()
        {
            //ArrayListler Obje Türündedir.
            //Tip güvenliği yok ise ArrayList kullanılabilir.
            //TypeSafe == Tip Güvenliği Demektir. Örneğin ben projemde String'ler ile çalışacağım anlamına gelir.
            //Add static Metodu ile istediğimiz kadar değer ekleyebiliriz.
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add("Balıkeisr");
            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }
        }
    }
    #endregion

    #region 3-TipGüvenliği
    //List'ler ile çalışmak
    //List'ler bizlere Generic'ler ile list güvenliği sağlamaktadır.
    class CityV3
    {
        public void Add()
        {
            List<string> cities = new List<string>();
            cities.Add("Ankara");
        }
    }

    //Daha ileri seviye List Kullanımı
    //List'ler Veritabanımızdaki karşılıklarını tutmak için çalıştığız Collections'lardır.
    class CustomerV3
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
    #endregion

    #region 4-Collections Metodları ile Çalışmak
    //Count ==> List'Deki Eleman sayıları Verir.
    //Add ==> Yeni Bir Elemean Ekleme.
    //AddRange ==> Array Bazlı (Eleman Sayılı) Listeleri ekler.
    //Clear ==> Bütün Listeyi Temizler.
    //Contains ==> Aradığımız Değer Varmı, Bulma İşlemi yapar.
    //Console.WriteLine(customers.Contains(new Customer{id =1 , FirstName ="Engin"})); ==> Bu kullanım hatalıdır.
    //Console.WriteLine(customers.Contains(customer2)); ==> Bu kullanım Doğrudur.

    //Gerekli Konulara bakarsın.
    #endregion

    #region 5-Dictionary
    //Bir anahtar ile Değere Ulaşmak münkündür.

    //ContainsKey ==> Anahtarı Arar True, False Döndürür.
    #endregion
}
