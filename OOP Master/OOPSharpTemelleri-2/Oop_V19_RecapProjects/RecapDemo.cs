using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oop_V19_RecapProjects
{
    public partial class RecapDemo : Form
    {
        public RecapDemo()
        {
            InitializeComponent();
        }

        private void RecapDemo_Load(object sender, EventArgs e)
        {
            ListProducts();
            ListCategories();
        }

        private void ListProducts()
        {
            //Bütün Ürünleri Listele
            //Garbage Collector Devremeye Girmeden Bellekten bu Using'li Kodu Siler
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.ToList();
            }
        }

        private void ListCategories()
        {
            //Combobox'a Kategoreleri Getir. 
            //Garbage Collector Devremeye Girmeden Bellekten bu Using'li Kodu Siler
            using (NorthwindContext context = new NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();
                //ComboBax'daki value'leri CategoryName'den Göster. // DisplayMember Demek
                cbxCategory.DisplayMember = "CategoryName";
                //ComboBax'daki Değerleri CategoryId'e göre İşleme Sok // ValueMember Demek
                cbxCategory.ValueMember = "CategoryId";
            }
        }   





        private void CbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Combobox Değiştiğinde Ürün Listesini Kategoriye Göre Değiştir.
            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch (Exception)
            {
                
            }
            
        }
        private void TbxSearch_TextChanged(object sender, EventArgs e)
        {
            //Textbox Değiştiğinde Database'de Arama yapar.
            string key = tbxSearch.Text;
            if (string.IsNullOrEmpty(key))
            {
                ListProducts();
            }
            else
            {
                ListProductsByProductName(tbxSearch.Text);
            }            
        }





        private void ListProductsByCategory(int categoryId)
        {
            //Ürünleri Combobox'tan gelen Kategoriye göre listele
            //Garbage Collector Devremeye Girmeden Bellekten bu Using'li Kodu Siler
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
        }
        private void ListProductsByProductName(string key)
        {
            //Ürünleri Textbox'tan gelen veriye göre listele
            //Garbage Collector Devremeye Girmeden Bellekten bu Using'li Kodu Siler
            //Sql Server Case-insensitive Yani Küçük büyük harf Duyarsız Çalışır. O Yüzden ToLower Ekledik.
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.ProductName.ToLower().Contains(key.ToLower())).ToList();
            }
        }
    }

    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 29 (Events) ===> Ders 116
    /// </summary>
    //Events
    // 1=£ VeriTabanı Oluşturulması

    #region 1-Veri Tabanı Oluşturulması
    //Google'ye NortWind yazıp Microsoft'tan database Exe'si İndirdik.
    //https://www.microsoft.com/en-us/download/confirmation.aspx?id=23654
    //Sonra Sql Server Object Explorer'dan Sol Üste New Query Sekmesiyle
    //İndirdiğimi Database'leri Düzenleden Hepsini Seçip New Query'in içerisine attım Çalıştır Butonuna Bastık
    #endregion

    #region 2-Arayüz Hazırlanması
    //Arayüz ve UI Elemanlarını isimlendirme İşlemi Yaptık.
    #endregion

    #region 3-EntiyFrameWork Configirasyonu
    //Orm
    //NorwindContext Adlı bir class Oluşturup ona bağlama işlemi yapıyoruz.
    //ManageNuget Packets'den Entity FrameWork'u Sisteme Dahil Etmemiz Gerekir.
    //Sonrasında NorwindContext İçerisine Entity Using'lemiz gerekiyor.
    //Ardından İse veritabanı tablolarımıza karşılık gelen Product Class'ını Oluşturuyoruz.
    //Sutunlara karşılık Property'leri Tanımlıyoruz.
    //Ardından NortwindContext içerisine using Oop_V18_RecapProjects.Entites; ekliyoruz.
    //Ardından NortwindContext DbContext'den inherit ediyoruz.
    //Son Olarak List of Products şeklinde Product Class'ından bir property Tanımlıyoruz.
    //App Config İçerisine Connection String(Veritabanı Bağlantı Adresi) Parametresine Ekliyoruz

    //<connectionStrings>
    //-------name = "NortwindContext" ========> Context Db'mizin Class'ını Temsil Eder... Eğer Mapping Yapmıyor isek Context'simizle Aynı ismi vermemiz gerekir.
    //-------connectionString="Data source=(localdb)\mssqllocaldb  ========> Bağlantı türünü Temsil Eder
    //-------initial catalog=Nortwind ========> Bu server'da hangi Veritabanı ? (Nortwind) ========> Veritabanı Temsil Eder
    //-------integrated security=true ========> Ben bu bilgisayara login olduğum hesapla (Windows Otantication) Direk Bilgisayar HEsabımı bağlanarak VeriTabanına Bağlan
    //<add name="NortwindContext" connectionString="Data source=(localdb)\mssqllocaldb;initial catalog=Nortwind;integrated security=true" providerName="System.Data.SqlClient"/>
    //</connectionStrings>

    //connectionstrings.com ========> Farklı Bağlantılar İçin Kaynak.
    #endregion


    //Operasyonlar Veri İletişim Katmanındadır. Class library Class'ları içerisinde barındıran Kütüphane, Dll Dosyası ==> 
    //Bütün Platformalrın (Web, Mobil, Destkop) == Veri İletişim Katmanına Yazırlır.

    //Bir Kural Getirerek Örneğin Ürünleri Listeleyecek ama şu birimde Çalışıyor ise Listeyebilir. Yani İnsan kaynakları Ürünleri Listeleyemesin
    //Ama Üretim Birimi Ürünleri listeyebilsin. Burada Bizim Süreçlerimiz ile ilgili kodlar oluşuyor bunada iş katmanı deniliyor.

    //Temel Olarak Üç Katman Vardır.
    //Arayüz Katmanı        ==> Textbox'lar, Label'lar, Gridler vs.
    //İş Katmanı Katmanı    ==> İş Katmanı bizim iş kurallarımızı içerir. Örneğin İnsan Kaynakları Data'lara Erişebilsin ama diğerleri erişemessin gibi.
    //Veri İletişim Katmanı ==> Veriyi listelediğimiz yerdir. Yani Veritabanına kodu gönderdiğimiz yerdir.

    //Üsteki katmanlar temel 3 katmanlı mimarilerdir.


    //Zamanla araya Servis odaklı mimariler geldiğinde, aralara bu katmanlarda koyulabildiği için, Artık o 3 katmanlı mimari çok katmanlı mimari 
    //yani nLayer application ==! Çok katmanlı mimariler denir.
    //Arayüz katmanı == Müşteri Listeler Görüntüler, Bilgileri Alır vs.
    //İş Katmanı Müşterinin == o kurala uyup uymadığını kontrol eder.
    //Veri İletişim Katmanı == Data access ise veritabanına müşteri kayıt eder, Siler yada günceller.
}

