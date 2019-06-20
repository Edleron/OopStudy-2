using System;
using System.Collections.Generic;

namespace Oop_o15_GenericClassesAndMetods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generic Sınıflar ve Metotdlar");

            Console.WriteLine("----------------------");

            #region 1-Generic Sınflar Giriş
            Console.WriteLine("1-Generic Sınflar Giriş");

            #endregion

            Console.WriteLine("----------------------");

            #region 2-Generic Metodlar
            Console.WriteLine("2-Generic Metodlar");
            UtilitiesV2 utilitiesV = new UtilitiesV2();
            List<string> resultF1 = utilitiesV.BuildList<string>("Ankara", "Balıkesir", "Adana");
            foreach (var item in resultF1)
            {
                Console.WriteLine(item);
            }

            List<CustomerV1A2> resultF2 = utilitiesV.BuildList<CustomerV1A2>(new CustomerV1A2 { Name = "Ertuğrul" }, new CustomerV1A2 { Name = "Gülnur" });

            foreach (var item in resultF2)
            {
                Console.WriteLine(item.Name);
            }
            #endregion

            Console.WriteLine("----------------------");

            #region 3-Generic Kısıtlar
            Console.WriteLine("3-Generic Kısıtlar");

            #endregion

            #region Daire
            double raidus;
            double thickness = 0.4;
            ConsoleColor BorderColor = ConsoleColor.Yellow;
            Console.ForegroundColor = BorderColor;
            char symbol = '*';
            do
            {
                Console.Write("Enter Radius::::");
                if (!double.TryParse(Console.ReadLine(), out raidus) || raidus <= 0)
                {
                    Console.WriteLine("Radius have to be postive number");
                }
            }
            while (raidus <= 0);
            Console.WriteLine();
            double rIn = raidus - thickness, rOut = raidus + thickness;
            for (double y = raidus; y >= -raidus; --y)
            {
                for (double x = -raidus; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }            
            #endregion

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 24 (Generic Sınıflar ve Metotdlar) ===> Ders 103
    /// </summary>
    //Generic Sınıflar ve Metotdlar
    // 1=£ Generic Sınflar Giriş
    // 2=£ Generic Metodlar
    // 3=£ Generic Kısıtlar


    //Generic'ler nesneye yönelik programlama yaparken hayati öneme sahiptirler.
    #region 1-Generic Sınflar Giriş

    #region One Examples
    interface IProductDalV1A1
    {
        List<ProductV1A1> GetAll();
        ProductV1A1 Get(int id);
        void Add(ProductV1A1 product);
        void Delete(ProductV1A1 product);
        void Update(ProductV1A1 product);

    }
    class ProductV1A1
    {

    }

    interface ICustomerDalV1A1
    {
        List<CustomerV1A1> GetAll();
        CustomerV1A1 Get(int id);
        void Add(CustomerV1A1 product);
        void Delete(CustomerV1A1 product);
        void Update(CustomerV1A1 product);

    }

    class CustomerV1A1
    {

    }
    #endregion



    #region Two Examples
    //Yukarıda bir çok interface oluşturduk. Ama içleri hep aynı sadece parametre sınıflar değişkenlik gösterdi.
    //Ama aşağıda ise generic bir interfa tanımlayıp, olayı dahada daha'da az kod yazar hale getirdik.
    //T Type'den Gelir

    //Repository Veritabanı işlemleri için kullanılan bir tasarım deseni isimlendirmesidir. yada operasyonudur.

    //Generic Repository
    interface IRepositoryV1A2<T>
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    #region Product
    class ProductV1A2
    {

    }
    interface IProductDalV1A2 : IRepositoryV1A2<ProductV1A2>
    {

    }
    class ProducDalV1A2 : IProductDalV1A2
    {
        public void Add(ProductV1A2 entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductV1A2 entity)
        {
            throw new NotImplementedException();
        }

        public ProductV1A2 Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductV1A2> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductV1A2 entity)
        {
            throw new NotImplementedException();
        }
    }


    #endregion

    #region Customer
    class CustomerV1A2
    {
        public string Name { get; set; }
    }
    interface ICustomerDalV1A2 : IRepositoryV1A2<CustomerV1A2>
    {

    }
    class CustomerDalV1A2 : ICustomerDalV1A2
    {
        public void Add(CustomerV1A2 entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CustomerV1A2 entity)
        {
            throw new NotImplementedException();
        }

        public CustomerV1A2 Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerV1A2> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerV1A2 entity)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #endregion

    #endregion



    #region 2-Generic Metodlar
    class UtilitiesV2
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }
    #endregion



    #region 3-Generic Kısıtlar
    #region ExaplesOne
    //Şart'da class yazar ise bu referans tipli şartı arar.
    interface IRepositoryV3A1<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    //String Referans Tipli olduğu için ve Şarta Class Yazıldığı için hata vermez
    interface IStudentDalV3A1 : IRepositoryV3A1<string>
    {

    }
    #endregion

    #region ExaplesTwo
    //Şart'da class yazar ise bu referans tipli ve New'lenen şartı arar.
    //şartları çoğaltmak için "," ile ekliyoruz
    interface IRepositoryV3A2<T> where T : class, new()
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    //String Referans Tipli olduğu için ve Şarta Class Yazıldığı için hata verir
    //interface IStudentDalV3A2 : IRepositoryV3A2<string>
    //{

    //}
    #endregion

    #region ExaplesThree
    //New Her Zaman En sona Koyulmalı

    //Referans Tipli Olmalı
    //IEntityV3A3 Miras Almalı
    //New'lenebilir olmalı
    interface IRepositoryV3A3<T> where T : class, IEntityV3A3, new()
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    //Ben Operasyonlarımı IRepositoryV3A3 İmplemente Edecek olduğumda
    //Referans Tipli Olmalı
    //IEntityV3A3 Miras Almalı
    //New'lenebilir olmalı
    //Bu Kurallara dikkat etmem gerekiyor
    interface IStudentDal : IRepositoryV3A3<StudentV3A3>
    {

    }

    //VeriTabanı Nesnesi
    interface IEntityV3A3
    {

    }

    class StudentV3A3 : IEntityV3A3
    {

    }
    #endregion

    #region ExaplesFour
    //Değer Tiplere Karşılık, Generic Şart Koyma
    interface IRepositoryV3A4<T> where T : struct
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }


    //Değer Şartını Verdik.
    interface IStudentDalV3A4 : IRepositoryV3A4<int>
    {

    }
    #endregion
    #endregion

}
