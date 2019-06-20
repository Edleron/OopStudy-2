using System;

namespace Oop_d4_InterfacePolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("İnterfaces & Polymorphism Konu Anlatımı");
            Console.WriteLine("----------------------");

            #region 1-Interfaces Giriş
            Console.WriteLine("Interfaces Giriş");
            PersonManagerV1 managerV1 = new PersonManagerV1();

            Custormers1V personV1 = new Custormers1V
            {
                Id = 1,
                FirstName = "Ertuğrul",
                LastName = "Doğancıoğlu",
                Departmant = "Computer Sciences"
            };

            Student1V studentV1 = new Student1V
            {
                //ctrl + space = Otamatik Propertleri gösterir.
                //ctrl + k ===> ctrl + d //// Kodları Düzeltir, Okunaklı Hale Getirir.
                //2 kere Tab Tab tuşuna basınca kodu otomatik tanımlar.
                Id = 1,
                FirstName = "Gülnur",
                LastName = "Doğancıoğlu",
                Adrees = "Balıkesir"
            };

            managerV1.Add(studentV1);
            #endregion

            Console.WriteLine("----------------------");

            #region 2-Gerçek Hayatta Interface Kullanımı
            Console.WriteLine("Gerçek Hayat Örneği");
            CustomerManagerV2 customerMangerV2 = new CustomerManagerV2();
            customerMangerV2.Add(new SqlServerCustomerDalV2());
            #endregion

            Console.WriteLine("----------------------");

            #region 3-Polymorphism
            Console.WriteLine("Polymorphism");
            ICustomerDalV3[] customersDalsV3 = new ICustomerDalV3[2]
            {
                new SqlServerCustomerDalV3(),
                new OracleCustomerDalV3()
            };
            foreach (var item in customersDalsV3)
            {
                item.Add();
            }
            #endregion

            Console.WriteLine("----------------------");

            #region 4-Çoklu Implementasyon
            Console.WriteLine("Çoklu Implementasyon");
            IWorkerV4[] workersV4 = new IWorkerV4[3]
            {
                new ManagerV4(),
                new RobotV4(),
                new WorkerV4()
            };
            foreach (var item in workersV4)
            {
                item.Work();
            }

            //Robot Yemek Yemez
            IEatV4[] eatV4 = new IEatV4[2]
            {
               new ManagerV4(),
               new WorkerV4()
            };

            foreach (var item in eatV4)
            {
                item.Eat();
            }
            #endregion

            Console.ReadLine();
        }
    }

    /// <summary>
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 12 (İnterfaces) ===> Ders 61
    /// </summary>
    //Interface & Polymorphism
    // 1=£ Interface'lere Giriş
    // 2=£ Gerçek Hayatta Interface Kullanımı
    // 3=£ Polymorphism
    // 4=£ Çoklu Implementasyon


    #region 1-Interfaces Giriş
    //İsimlendirme Standartlarına Göre interfaces'ler I harfi ile Başlamak Zorundadır. 
    //**** Temel Operasyon yada Temel Nesne Oluşturup, Bütün Nesneleri Ondan İmpelemented Ederek Operasyonel Kodlar Yazılmasını Sağlar.

    //Interfacesler Soyut Nesnelerdir. Tek Başlarına Anlam İfade Etmezler 
    //Kendi Başkarına New'lenemezler. Yani İnstance oluşturulamazlar
    //IPerson person = new IPerson(); ==£ Yapılması münkün değildir.

    //İnterface ve Abstract Classları İnstance oluşturulamazlar. Ancak Class'lara Implemented edilebilirler.
    interface IPerson1V
    {
        //Interfacesler yazır iken tamamen imzası gerekir. Yani bir Access Modifiers'a gerek yoktur.
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }


    //Altaki Nesneler Somut Nesneler Adı Verilir.
    //Student1V:IPerson1V ==£ IPerson1V Student1V ":" ile implemente ediyor.
    class Student1V : IPerson1V
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adrees { get; set; }
    }

    //Custormers1V :IPerson1V ==£ IPerson1V Custormers1V ":" ile implemente ediyor.
    class Custormers1V : IPerson1V
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Departmant { get; set; }
    }

    class PersonManagerV1
    {
        public void Add(IPerson1V person)
        {
            Console.WriteLine(person.FirstName);
        }
    }
    #endregion

    #region 2-Gerçek Hayatta Interface Kullanımı
    //Dal = Data Acces Layer'dan gelir. Veri Tabanı İşlemleri bu dal sınıfında gerçekleştiği için isimlendirmede buna uygun verilir.
    //Burada tanımlanan bir interfaces somut nesnelere implemente edilerek, Durumların değişme esnekliği kod tarafında yarar sağlar.
    //customerMangerV2.Add(new SqlServerCustomerDalV2()); tipi ile isteğe göre kod gerçekliği gerçekleştirir.
    interface ICustomerDalV2
    {
        void Add();
        void Update();
        void Delete();
    }

    class SqlServerCustomerDalV2 : ICustomerDalV2
    {
        public void Add()
        {
            Console.WriteLine("Sql Added");
        }

        public void Delete()
        {
            Console.WriteLine("Sql Deleted");
        }

        public void Update()
        {
            Console.WriteLine("Sql Updated");
        }
    }

    class OracleCustomerDalV2 : ICustomerDalV2
    {
        public void Add()
        {
            Console.WriteLine("Oracle Added");
        }

        public void Delete()
        {
            Console.WriteLine("Oracle Deleted");
        }

        public void Update()
        {
            Console.WriteLine("Oracle Updated");
        }
    }

    class PhpMyAdminCustomerDalV2 : ICustomerDalV2
    {
        public void Add()
        {
            Console.WriteLine("PhpMyAdmin Added");
        }

        public void Delete()
        {
            Console.WriteLine("PhpMyAdmin Deleted");
        }

        public void Update()
        {
            Console.WriteLine("PhpMyAdmin Updated");
        }
    }

    class CustomerManagerV2
    {
        public void Add(ICustomerDalV2 customersDalV2)
        {
            customersDalV2.Add();
        }
    }

    #endregion

    #region 3-Polymorphism
    //ICustomerDalV3'ü SqlServerCustomerDalV3 ve OracleCustomerDalV3 Şeklinde Implemente Etme İşlemine Polymorphism denir.
    //Polymorphism = bir soyut nesnenin birden fazla etki ettiği somut nesne türüne verilen isimdir.

    //Statik Polymorphism = metot ve operatörlerin aşırı yüklenmesi (overload) olarak belirtilir.
    //Dinamik Polymorphism = özet sınıflardan miras alma yoluyla işlemlerin gerçekleştirilmesi işlemine verilen isimdir.

    //Sonuç olarak, Polymorphism bir nesnenin bir işlemi farklı şekillerde yapabileceğini gösteren bir kavramdır.
    //Birbirine benzeyen nesneleri ortak özellikleriyle ele alabilmenizi ya da bir nesnenin aynı işi farklı şekillerde yapabilmesini sağlar. 
    interface ICustomerDalV3
    {
        void Add();
        void Update();
        void Delete();
    }

    class SqlServerCustomerDalV3 : ICustomerDalV3
    {
        public void Add()
        {
            Console.WriteLine("Sql Added");
        }

        public void Delete()
        {
            Console.WriteLine("Sql Deleted");
        }

        public void Update()
        {
            Console.WriteLine("Sql Updated");
        }
    }

    class OracleCustomerDalV3 : ICustomerDalV3
    {
        public void Add()
        {
            Console.WriteLine("Oracle Added");
        }

        public void Delete()
        {
            Console.WriteLine("Oracle Deleted");
        }

        public void Update()
        {
            Console.WriteLine("Oracle Updated");
        }
    }

    class CustomerManagerV3
    {
        public void Add(ICustomerDalV3 customersDalV3)
        {
            customersDalV3.Add();
        }
    }

    #endregion

    #region 4-Çoklu Implementasyon
    //Burada yapılan işlem Interfaces'lerin doğru planlanması idi, Bunu Yazılım Geliştirme Prensiplerinden ***Solid*** dediğimiz, 5 Tane Yazılım Geliştirme Prensibi vardır.
    //Bu Prensipler bir yazılımcı için hayati önem taşımaktadır.
    //Biz burada İnterface'in doğru planlanmasını gerektiğini söyleyen prensibin, Solid'in I harfine denk gelen, 4. prensibi ==>  ****Interface Segregation Principle***** Örneğini yaptık.

    //SOLID
    //S == >> Single Responsibility Principle
    //O == >> Open/Closed Principle
    //L == >> Liskov ‘s Substitution Principle
    //I == >> Interface Segregation Principle
    //D == >> Dependency Inversion Principle
    //https://medium.com/@techmostal/solid-yaz%C4%B1l%C4%B1m-geli%C5%9Ftirme-prensipleri-86a236f6e961
    interface IWorkerV4
    {
        void Work();
    }

    interface IEatV4
    {
        void Eat();
    }

    interface ISalaryV4
    {
        void GetSalary();
    }


    class ManagerV4 : IWorkerV4, IEatV4, ISalaryV4
    {
        public void Eat()
        {
            Console.WriteLine("Manager Yemek Ye");
        }

        public void GetSalary()
        {
            Console.WriteLine("Manager Maaş Al");
        }

        public void Work()
        {
            Console.WriteLine("Manager Çalış");
        }
    }

    class WorkerV4 : IWorkerV4, IEatV4, ISalaryV4
    {
        public void Eat()
        {
            Console.WriteLine("Worker Yemek Ye");
        }

        public void GetSalary()
        {
            Console.WriteLine("Worker Maaş Al");
        }

        public void Work()
        {
            Console.WriteLine("Worker Çalış");
        }
    }

    class RobotV4 : IWorkerV4
    {
        public void Work()
        {
            Console.WriteLine("Robot Çalış");
        }
    }
    #endregion


}
