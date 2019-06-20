using System;
using System.Collections.Generic;

namespace Oop_l12_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exception Handling");

            Console.WriteLine("----------------------");

            #region 1-Exception Handling Giriş
            Console.WriteLine("1-Exception Handling Giriş");
            try
            {
                string[] students = new string[3] { "Ertuğrul", "Gülnur", "Şiir" };

                students[3] = "Ahmet";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            #endregion

            Console.WriteLine("----------------------");

            #region 2-Kendi Exception Sınıfımız
            Console.WriteLine("2-Kendi Exception Sınıfımız");
            //Ön Yüz Programlama
            try
            {
                Find();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            #endregion

            Console.WriteLine("----------------------");

            #region 3-Aciton Delegasyonu ile Hata Ayıklama
            Console.WriteLine("3-Action Delegasyonu ile Hata Ayıklama");
            //Bu yapı ile Find() Metodunu Baska Bir Metoda Parametre olarak Gönderme İşlemi Yaptık.
            HandleException(() =>
            {
                Find();
            });
            #endregion

            Console.ReadLine();
        }



        #region  2-Kendi Exception Sınıfımız
        //BackEnd Programlama
        private static void Find()
        {
            List<string> Students = new List<string> { "Ertuğrul", "Gülnur", "Ahmet" };
            if (!Students.Contains("Engin"))
            {
                throw new RecordNotFoundException("Record not Found");
            }
            else
            {
                Console.WriteLine("Record Found ! ");
            }
        }
        #endregion


        #region 3-Aciton Delegasyonu ile Hata Ayıklama
        //Parametre Haricinde Metod'un Kendisi Gönderme İşlemi
        private static void HandleException(Action action)
        {
            try
            {
                //Invoke Kodu == Bu Gelen Metod'u çalıştır Demek.
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        #endregion
    }

    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 20 (Hata Yönetimi) ===> Ders 86
    /// </summary>
    //Exceptions - Hata Ayıklama - Try Catch
    // 1=£ Exception Handling Giriş
    // 2=£ Kendi Exception Sınıfımız
    // 3=£ Aciton Delegasyonu ile Hata Ayıklama

    #region 1-Exception Handling Giriş

    #endregion

    #region 2-Kendi Exception Sınıfımız
    public class RecordNotFoundException : Exception
    {
        //Base Contructors sayesinde kendi mesaj sınfımızın yayınlanmasını sağlayan kod bloğu
        public RecordNotFoundException(string message) : base(message)
        {

        }
    }
    #endregion

    #region 3-Aciton Delegasyonu ile Hata Ayıklama
    //Parametre Haricinde Metod'un Kendisi Gönderme İşlemi

    #endregion
}
