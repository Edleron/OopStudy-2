using System;

namespace Oop_u17_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Events");
            #region 2-Events Exaples
            Console.WriteLine("2-Events Exaples");
            Product hardisk = new Product(50);
            hardisk.ProductName = "Hard Disk";

            Product gsm = new Product(100);
            gsm.ProductName = "Gsm";
            gsm.StockControlEvent += Gsm_StockControlEvent;
            for (int i = 0; i < 10; i++)
            {
                hardisk.Sell(10);
                gsm.Sell(10);
                Console.ReadLine();

            }
            #endregion

            Console.ReadLine();
        }

        private static void Gsm_StockControlEvent()
        {
            Console.WriteLine("Gsm About Finish !");
        }
    }

    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 28 (Events) ===> Ders 114
    /// </summary>
    //Events
    // 1=£ Events'leri Anlamak
    // 2=£ Events Exaples

    #region 1-Events'leri Anlamak
    //Bir olay gerçekleştiğinde birden fazla fonksiyonu çağırmak istediğinizi düşünelim. 
    //Örneğin kullanıcı bir düğmeye tıkladığında birden fazla method'un otomatik olarak çağrılmasını istiyorsunuz. 
    //Bunun için delagate kullanabilirsiniz. Burada amaç şu. Bir olay olduğunda birden fazla yere bu olayı bildirebilmek. 
    //Bu olay ile ilgilenler delegate ile olaydan haberleri olur.
    //delagate olarak bir method tanımlanır.Bu method aslında temsilcidir.Bir olay 
    //olduğunda siz delegate method'unu çağrırsınız. delegate method'una kendisini ekleyen method'lar 
    //otamatik olarak çağrılırlar.


    //Event'ler dalegate'lere benzer. Ancak daha iyi özelliklere sahiptir. 
    //Event'ler genellikle GUI konponentleri için kullanılan bir kavram. 
    //Örneğin bir düğmenin tıklanması bir event oluşturur. Veya farenin hareket etmesi, tıklama bu tür "olay"lar bir Event oluştururlar. 
    //Aynı şekilde herhangi bir özellikleki değişme için siz bir event yaratabilirsiniz. 
    //Bu event'i dinleyenler event'in oluşundan haberdar olur. Yukarıdaki örneğe göre düşünürsek. 
    //Kullanıcının bir sayı girmesi bir event oluşturabilir. Oluşan event dinleyicilere bildirilir.

    //Delegeler metodları dolaylı olarak başlatmamıza izin verirler. 
    //Metodları başlatmamız için delegeyi açık bir şekilde başlatmamız gerekir. 
    //Ancak bazı durumlarda biz başlatmasakta metodun kendiliğinden çalışmasını isteyebiliriz. 
    //İşte bu gibi durumlarda Event kullanmamız gerekir. 
    //Örneğin bir cihazın şarjı bitmek üzereyse ışığının otomatik olarak kısılmasının sağlanması 
    //yada aşırı ısınmış olan bir cihazda uygulamanın kapatılmasını sağlamak gibi durumlar düşünülebilir.

    //Event kavramı bir çok yerde karşımıza çıkmaktadır, 
    //bunlara örnek olarak bir butona tıklanması veya mouse ile sağ click tıklanması gibi olaylar gösterilebilir.
    //Event bildirirken, öyle bir sınıf tasarlamalıyız ki uygulamada istediğimiz yerleri izlesin ve 
    //olağan dışı yada önemli bir durum olduğunda Event çağırabilsin.
    //Bir Event tanımlarken türü delegate olmalı ve event anahtar sözcüğü kullanmalısınız.

    //Eventler Delege'dir. Delegenin Kullanımları ile Eventler Kullanılabilir.
    #endregion

    #region 2-Events Exaples


    #endregion
}
