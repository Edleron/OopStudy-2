using System;

namespace Oop_e5_Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inheritance");

            Console.WriteLine("----------------------");

            #region 1-Inheritance Giriş
            Console.WriteLine("Inheritance Giriş");
            PersonV1[] personV1 = new PersonV1[3]
            {
                new CustomersV1
                {
                    FirstName ="Gülnur"
                }, new StudentV1
                {
                    FirstName = "Ertuğrul"
                },
                new PersonV1
                {
                    FirstName = "Şiir"
                }
            };

            foreach (var item in personV1)
            {
                Console.WriteLine(item.FirstName);
            }
            #endregion

            Console.WriteLine("----------------------");

            #region 3-Virtual Metodlar
            Console.WriteLine("Virtual Metodlar");
            SqlServerV3 sqlServerV3 = new SqlServerV3();
            sqlServerV3.Add();
            MySqlV3 mySqlV3 = new MySqlV3();
            mySqlV3.Add();
            #endregion

            Console.ReadLine();
        }
    }

    /// <summary>
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 13 (Inheritance) ===> Ders 66
    /// </summary>
    //Inheritance
    // 1=£ Inheritance Giriş
    // 2=£ Interface ve Inheritance Arasında Karar Verme Süreçleri
    // 3=£ Virtual Metodlar.

    #region 1-Inheritance Giriş
    //Miras Kalıtım Aldığımız Yapılardır.
    //Interfaces'lerde Birer Inheritance Örneği gibi çalışırlar, Fakat onlar inheritance yapmazlar O bir İmplementasyon kuralını uygularlar. Fakat İnheritance gibi kullanılmalarıda münkündür.
    //Ebeveny - Çocuk ilişkisi mevcuttur.
    //Üst sınıftan alınan property'ler kullanılabilir.
    //Alt sınıflarda yeni property'ler Tanımlanabilir

    //Bir nesneyi bir kez miras alabilirsiniz, Ama bir den fazlakez implementeasyon (interfaces) uygulayabilirsiniz.
    //Inheritance Önce yazılır, Sonrasında Implementasyonlar yazılır.
    //Class'ların tek başlarına anlamları vardır, Ama İnterfaces'lerin tek başlarına anlam ifade etmezler.
    class PersonV1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class CustomersV1 : PersonV1
    {
        public string City { get; set; }
    }

    class StudentV1 : PersonV1
    {
        public string Departman { get; set; }
    }
    #endregion

    #region 2-Interface mi Yoksa Inheritance mı ?
    //Eğer bir kümede birden fazla durumla karşılaşılıyor ise, Interface'lerden yürümek her zaman daha mantıklıdır.
    //Inheritance ye ihtiyamız olmadığı durumlarda, İnterfaces'lerden yürümek daha mantıklıdır.
    #endregion

    #region 3-Virtual Metodlar
    //Ne zaman interface ne zaman inheritance kullanmamızda yol gösterir.
    //Base Sınıfta tanımlanan Virtual Keyword Metodu, Child Sınıfta Override Edilerek Ezilir.

    class DatabaseV3
    {
        public virtual void Add()
        {
            Console.WriteLine("Added by default");
        }

        public void Deleted()
        {
            Console.WriteLine("Deleted by default");
        }
    }

    class SqlServerV3 : DatabaseV3
    {
        public override void Add()
        {
            //Base Demek Miras Alınan Üst Sınıvı Kast Eder. Base == DatabaseV3

            Console.WriteLine("Added By Sql Code");


            //Bu kod Base Sınıfı Add'ini Çalışıtır.
            //base.Add();
        }
    }
    class MySqlV3 : DatabaseV3
    {
        public override void Add()
        {
            //Bu kod Base Sınıfı Add'ini Çalışıtır.
            base.Add();
        }
    }
    #endregion
}
