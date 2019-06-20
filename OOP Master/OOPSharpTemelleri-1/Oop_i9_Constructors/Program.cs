using System;

namespace Oop_i9_Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Constructors");

            Console.WriteLine("----------------------");

            #region 1-Constructors Giriş
            Console.WriteLine("1-Constructors Giriş");
            CustomerManagerV1 manager = new CustomerManagerV1(10);
            manager.List();
            #endregion

            Console.WriteLine("----------------------");

            #region 2-Constructors Örnekleri
            Console.WriteLine("2-Constructors Örnekleri");
            //Sınıfa Parametre Ekleme -1
            ProductV2 productV2A1 = new ProductV2();
            productV2A1.Id = 1;
            productV2A1.Name = "Gülnur";
            //Sınıfa Parametre Ekleme -2
            ProductV2 productV2A2 = new ProductV2
            {
                Id = 1,
                Name = "Ertuğrul"
            };
            //Sınıfa Parametre Ekleme -3 Constructors ile 
            ProductV2 productV2A3 = new ProductV2(3, "Gizem");
            #endregion

            Console.WriteLine("----------------------");

            #region 3-Constructors Injection
            Console.WriteLine("3-Constructors Injection");
            CustomersManagerV3 managerV3 = new CustomersManagerV3(new DatabaseLoggerV3());
            managerV3.Add();
            #endregion

            Console.WriteLine("----------------------");

            #region 4-Constructors ile Base Sınıfa Parametre Yollama
            Console.WriteLine("4-Constructors Base Class");
            PersonManagerV4 personManagerV4 = new PersonManagerV4("Product");
            personManagerV4.Add();
            #endregion

            Console.WriteLine("----------------------");


            #region 5-Static Class ve Metodlar
            Console.WriteLine("5- Static Class ve Metodlar");
            TeacherV5.Number = 10;
            UtilitiesV5.Validate();

            //İnstance Üretmenden
            ManagerV5.DomeSomethingF1();

            //İnstance Üreterek
            ManagerV5 managerV5 = new ManagerV5();
            managerV5.DomeSomethingF2();

            #endregion

            Console.ReadLine();
        }
    }

    /// <summary>
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 17 (Constructors) ===> Ders 74
    /// </summary>
    //Constructors
    // 1=£ Constructors Giriş
    // 2=£ Constructors Örnekleri
    // 3=£ Constructors Injection
    // 4=£ Constructors ile Base Sınıfa Parametre Yollama
    // 5=£ Static Class ve Metodlar


    #region 1-Constructors Giriş
    //Bir sınıf temel anlamda new'lendiğinde yani instance alındığında, Çalışacak kod bloğudur.
    //Private bir field "_" (Alt çizgi) ile başlar.
    //Metod halinde alt çizgi kullanılmaz.
    class CustomerManagerV1
    {
        private int _count = 1;

        //Parametresiz Contructors
        //Contructorsler overloading edilebilir.
        public CustomerManagerV1()
        {

        }
        public CustomerManagerV1(int count)
        {
            _count = count;
        }
        public void List()
        {
            Console.WriteLine("Listed {0} items", _count);
        }

        public void Add()
        {
            Console.WriteLine("Added");
        }
    }
    #endregion


    #region 2-Constructors Örnekleri
    class ProductV2
    {
        public ProductV2()
        {

        }

        private int _id;
        private string _name;

        public ProductV2(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    #endregion


    #region 3-Constructors Injection
    //Bu Örnek Çok Önemli Sürekli Kullan
    interface ILoggerV3
    {
        void Log();
    }
    class DatabaseLoggerV3 : ILoggerV3
    {
        public void Log()
        {
            Console.WriteLine("Logged to Database");
        }
    }
    class FileLoggerV3 : ILoggerV3
    {
        public void Log()
        {
            Console.WriteLine("Logged to File");
        }
    }
    class CustomersManagerV3
    {
        private ILoggerV3 _logger;
        public CustomersManagerV3(ILoggerV3 logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added!");
        }
    }
    #endregion


    #region 4-Constructors ile Base Sınıfa Parametre Yollama
    //Base Sınıfa Parametre Gönderme İşlemi
    class BaseClassV4
    {
        private string _message;
        public BaseClassV4(string message)
        {
            _message = message;
        }
        public void Message()
        {
            Console.WriteLine("{0} Message", _message);
        }
    }
    class PersonManagerV4:BaseClassV4
    {
        public PersonManagerV4(string entity) : base(entity)
        {

        }

        public void Add()
        {
            Console.WriteLine("Added!");
            Message();
        }
    }

    #endregion

    #region 5-Static Class ve Metodlar
    //**//Ödev ==> Singleton Desing Pattern'e Bak

    //Static varlıklar class seviyesinde olabilir.
    //Static nesneler instance yani newleme işlemi yapılmaz
    //Static nesneler paylaşılan bir kaynak olmak zorundadır.
    //Belleğin Hafızasında Bulunur.
    //Static nesneler ortak nesnelerdir. Herkes kullanabilir.
    static class TeacherV5
    {
        public static int Number { get; set; }
    }

    //İş yap Bitir.
    static class UtilitiesV5
    {
        static UtilitiesV5()
        {

        }
        public static void Validate()
        {
            Console.WriteLine("Validation is done !");
        }
    }

    //Static Bir Sınıfın Her Üyesi Statik Olmak Zorundadır.
    class ManagerV5
    {
        public static void DomeSomethingF1()
        {
            Console.WriteLine("Done-1");
        }

        public void DomeSomethingF2()
        {
            Console.WriteLine("Done-2");
        }
    }
    #endregion
}
