using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oop_V18_RecapProjects
{
    public partial class RecapDemo : Form
    {
        public RecapDemo()
        {
            InitializeComponent();
        }

        private void RecapDemo_Load(object sender, EventArgs e)
        {
            //using Garbage Collector Beklemeden Bellekten İşlemi Yap ve Uçur Demek.
            using (NortwindContext context = new NortwindContext())
            {
                dgwProduct.DataSource = context.Products.ToList();
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
}
