using System;

namespace Oop_g7_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Logger = new FileLogger();
            customerManager.Add();
            Console.ReadLine();
        }
    }
    //Hiç bir zaman class'ları Çıplak bırakma, Sürekli soyutmalaya çalış

    class CustomerManager
    {
        public ILogger Logger { get; set; }
        public void Add()
        {
            Logger.Log();
            Console.WriteLine("Customer Added !");
        }
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Databese Logged !");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("File Logged !");
        }
    }


    class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Sms Logged !");
        }
    }
    interface ILogger
    {
        void Log();
    }
}
