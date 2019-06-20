using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oop_n14_EntityFrameWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Added");
        }       

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text.ToString(),
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
            });
            LoadProducts();
            MessageBox.Show("Updated");
        }        

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Deleted");
        }

        private void DgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void TbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);
        }

        private void TbxId_Click(object sender, EventArgs e)
        {
            _productDal.GetByID(1);
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }


        
        private void SearchProducts(string key)
        {
            //Collentions'lara Filtre Yazabiliriz.
            //Veritabanıda yazabiliriz

            //Şu anda Collections'lara sorgu atıcaz
            //Bunun için Lamba İfadesi kullanılır. ==> Buna yöntemin isim delegasyondur, (Preticittir = Yanlış olabilir.).

            //p=> ///Listedeki her eleman için
            //p=>p.Name ///Git Name'mine Bak
            //p => p.Name.Contains(key) ///key string değeri Varmı



            //DataGrid'e Direk Set et (Collections Linq to objects ile)
            //dgwProducts.DataSource = _productDal.GetAll().Where(p=>p.Name.Contains(key)).ToList();

            //Result Kullanarak datayı set et (Collections Linq to objects ile)
            //var result = _productDal.GetAll().Where(p => p.Name.Contains(key)).ToList();

            //Collections'lar Büyük küçük harf duyarlılığı vardır.
            //Result Kullanarak datayı set et (Collections Linq to objects ile)
            //Hepsini Küçük harf büyük hard duyarlılığı ortadan kaldırdık. ToLower()
            var result = _productDal.GetAll().Where(p => p.Name.ToLower().Contains(key.ToLower())).ToList();
            
            //var result = _productDal.GetByName(key);
            dgwProducts.DataSource = result;
        }

      
    }

    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 22 (Entity FrameWork) ===> Ders 98
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 23 (LINQ) ===> Ders 101
    /// </summary>
    //Entity Framework
    // 1=£ Entity FrameWork

    // 2=£ LINQ Giriş


    #region 1-Entity FrameWork
    //Proje ÜZerine Gel Sağ Tıkla "Managa Nuget Packets" Aç Sonra Browser'dan Entity Frame Work'u sen.

    //Normade ETradeContext Sınıfı Bellekte çok pahalı'yer kaplamaktadır.
    //ETradeContext context = new ETradeContext() ==>Bu şekildede kullanılablir. Lakin, Bu işlem bittiğinde Garbage colletor. Devreye girer, ve bellekten temizler.
    //Using kullanımında ise, bu işlem bitmeden zorla garbage collecter devreye sokularak. pahalı işlemleri ucuzlatma işlemi yapılır.

    //Databese connection bağlantı kodu ==>Solution Explorer'da Proje içerisinde (Oop_n14_EntityFrameWork), App.config içersinde yazılmaktadır.

    //Veritabanına karşılık gelen Product Class'ını oluşturduk.
    //ETradeContext ile Veri Tabanı Sorguları Yapan Class'ını oluşturduk.
    //ProductDal ile Operasyonlarımız Yazdık
    //Form ile FrontEnd Programlaması yapıp kullanıcıya bilgileri set ettik.
    #endregion

    #region 2-LINQ Giriş
    //İster Entiy FrameWork
    //İster Collections
    //Dile Özgü Sorgulama Mimarisine Verilen İsim LINQ diye adlandılır.

    //C# içerisinde İster Collections yada dizi olsun, yada Veritabanına sorgulama için olsun Sorgulama yapmamıza yarar
    //Nesneler için olan Linq object
    //Entity FrameWork için olan Linq to Entitys
    //Mimari Aynıdır.
    #endregion

}
