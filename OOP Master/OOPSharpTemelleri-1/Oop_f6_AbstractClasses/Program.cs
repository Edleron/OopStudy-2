using System;

namespace Oop_f6_AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Abstract Clases");

            Console.WriteLine("----------------------");

            #region 1-Abstract Classes
            Console.WriteLine("Abstract Classes");
            DataBaseV1 dataBaseV1 = new OracleV1();
            dataBaseV1.Add();
            dataBaseV1.Delete();
            #endregion
        }
    }

    /// <summary>
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 14 (Abstract Classes) ===> Ders 69
    /// </summary>
    //Abstract Classes
    // 1=£ Abstract Classes

    #region 1-Abstract Classes
    //Interfaces'lerde Amaç === İmzaları oluşturmak ve onu Implemente eden sınıfın bütün imzaları tekrardan yazmasını sağlamaktır, Bunu Zorunlu hale getirme işlemi yapıyorduk. 
    //Aynı zamanda Inheritance gibi kullanılabilir.

    //Virtual Metotlarda, Temel Operasyonlarımız vardır. İsteyen istediği operasyonu ezebiliyordu.

    //Abstract Classlar ise, Interfaces'ler ile Virtual Metodların(Inheritance) birleşimi gibi düşünülebilir.
    //Tamamen Inheritance(Miras Alma) amacı ile kullanılır.


    //Örnek Senaryo = Add İşlemi Bütün Child Sınfılarda Aynıdır. Lakin Delete İşlemi Farklıdır.
    //Abstract Class'lar ile Hem Tamamlanmış, Hemde Tamamlanmamış Metodlar Geliştirilebilirnir.

    //Abstract Class'lar Instance(newleme yapılmaz) alınamaz.

    abstract class DataBaseV1
    {
        //Tamamlanmış Metodlar.
        public void Add()
        {
            Console.WriteLine("Added by Default");
        }


        //Tamamlanmamış Metodlar.
        public abstract void Delete();
    }

    //Abstarct Metodlar içi dolu olmayan virtual metodlara benzerler.
    class SqlServerV1 : DataBaseV1
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted By SqlServer");
        }
    }

    class OracleV1 : DataBaseV1
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted By Oracle");
        }
    }
    #endregion

}
