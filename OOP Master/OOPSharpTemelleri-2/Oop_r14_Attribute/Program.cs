using System;

namespace Oop_r14_Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Attributes");

            Console.WriteLine("--------------");

            #region 1-Attributes
            Console.WriteLine("1-Attributes");
            CustomerV1 customerV1 = new CustomerV1 { Id = 1, LastName = "Doğancıoğlu", Age = 24 };
            CustomerDalV1 customerDalV1 = new CustomerDalV1();
            customerDalV1.Add(customerV1);
            #endregion

            Console.WriteLine("--------------");

            #region 2-Attributes Özellikleri
            Console.WriteLine("2-Attributes Özellikleri");
            #endregion

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 25 (Attributes) ===> Ders 106
    /// </summary>
    //Attributes
    // 1=£ Attributes Giriş
    // 2=£ Attributes Target ve Multiple Özellikleri

    #region 1-Attributes
    // Attributlere Parametre Gönderilebilinir.
    [ToTable("Customers")] // Veritabanında Customers Tablosuna Karşılık Gelir
    class CustomerV1
    {
        public int Id { get; set; }
        [RequiredProperty] //Zorunlu girilmesi gerekir
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }
    class CustomerDalV1
    {
        [Obsolete("Don't use Add, instead use AddNew Method")] //Hazır Attribute Bunu Kullanma Demek
        public void Add(CustomerV1 customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added ! ", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }

        public void AddNew(CustomerV1 customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added ! ", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }
    class RequiredPropertyAttribute : Attribute
    {

    }
    class ToTableAttribute :Attribute
    {
        private string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
    #endregion

    #region 2-Attributes Özellikleri
    [RequiredPropertyV2A1]
    [RequiredPropertyV2A1]
    class CustomerV2A1
    {
        [RequiredPropertyV2A2]
        public int Id { get; set; }
        [RequiredPropertyV2A2] //Zorunlu girilmesi gerekir
        public string FirstName { get; set; }
        [RequiredPropertyV2A2]
        public string LastName { get; set; }
        [RequiredPropertyV2A2]
        public int Age { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple =true)]//Classlara Attribute Ekledik //AllowMultiple Bİrden Fazla Attribute Eklemize Olanak Sağlar
    class RequiredPropertyV2A1Attribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]//Classlara Attribute Ekledik
    class RequiredPropertyV2A2Attribute : Attribute
    {

    }

    #endregion
}
