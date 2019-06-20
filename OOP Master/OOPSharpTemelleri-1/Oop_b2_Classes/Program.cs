using System;

namespace Oop_b2_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Classlar Konu Anlatımı");

            Console.WriteLine("----------------------");

            #region 3-Property 
            Console.WriteLine("Property");
            CustomersF3A1 customersF3A1 = new CustomersF3A1();
            customersF3A1.Id = 1;
            customersF3A1.FirstName = "Ertuğrul";
            customersF3A1.LastName = "DOĞANCIOĞLU";
            customersF3A1.City = "Balıkesir";

            Console.WriteLine(customersF3A1.FirstName);

            CustomersF3A1 customersF3A2 = new CustomersF3A1
            {
                Id = 2,
                City = "Balıkesir",
                FirstName = "Gülnur",
                LastName = "DOĞANCIOĞLU"
            };
            Console.WriteLine(customersF3A2.FirstName);


            #endregion

            Console.WriteLine("----------------------");

            #region 4-Getter-Setter & Encapsolution
            Console.WriteLine("Getter-Setter & Encapsolution");
            CustomersF4A1 customersF4A1 = new CustomersF4A1
            {
                Id = 1,
                FirstName = "Gülnur",
                LastName = "DOĞANCIOĞLU",
                City = "Balıkesir"
            };

            Console.WriteLine(customersF4A1.FirstName);
            #endregion

            Console.ReadLine();
        }
    }

    /// <summary>
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 10 (Classlar) ===> Ders 58
    /// </summary>
    //Classes
    // 1=£ Classlar
    // 2=£ Field
    // 3=£ Property
    // 4=£ Getter-Setter & Encapsolution

    #region 1-Classes
    //Nesneye Dayalı Programlama, Kodların bütünlüğü ve Kütüphane(Çervere FrameWorkd) Oryantasyonu yapmamızı sağlar.
    class ClassF1A1
    {

    }
    #endregion


    #region 2-Field
    //Field Tanımalamak
    class ClassF2A1
    {
        private string _firstName;
    }
    #endregion


    #region 3-Property
    //Property Tanımlamak
    //Özellikleri Tutmak
    //Bir Nesnenin Özelliklerini Tutabildiğimiz Alanlara Property İsmi Verilir. Field'lar ile İşlem Yapılmaz ama Property'ler ile işlem yapılabilir.
    //Class'ın özelliklerini Tanımlayacak isek Property Tanımlanır.
    //Veritanında Klon'lara karşılık Gelir
    class CustomersF3A1
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
    #endregion


    #region 4-Getter-Setter & Encapsolution
    //Getter ve Setter Encapsolution işinin temelini oluşturmaktadırlar.
    //Getter ve Setter'lar ile Property tanımlanarak, Field alanları gizleme işlemi yapılır.
    //Bu olaya Encapsolution işlemi denir.
    //Getter ve Setter'ları kullanılarak field'ları implementasyon gizleme işlemine verilen isimdir.
    //Field alanlarının doldurulur.
    //Oto Property
    class CustomersF4A1
    {
        public int Id { get; set; }
        private string _firstname;
        public string FirstName
        {
            get
            {
                return "Mr. and Mrs. " + _firstname;
            }
            set
            {
                _firstname = value;
            }
        }
        public string LastName { get; set; }
        public string City { get; set; }
    }
    #endregion
}
