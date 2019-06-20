using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oop_m13_AdoNet
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
            MessageBox.Show("Product Added!");
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }


        private void DgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text.ToString(),
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
            };
            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("Updated!");
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("Deleted !");
        }
    }

    /// <summary>
    /// Çok Önemli
    ///https://www.udemy.com/c-sharp-kursu/ ==> Bölüm 21 (AdoNet) ===> Ders 89
    /// </summary>
    //Ado_Net
    // 1=£ Veri Tababanı Oluşturulması

    #region 1-Veri Tababanı Oluşturulması
    //Wiew ==>  SQL Server Object Explorer Tıkla
    //Sol Tarafta Menü GElecek (localdb)\MSSQL..... Giden Butoana Sağ Tıklayıp "Add Database" Seçeneği Seç İsmi "ETrade" Olsun
    //Primary Key Tanımlanması İçin İlk Satıra tıklayıp "Id" değerini yazıp ==> Ardından Sağ Tarafta "Properties Penceresinde" ==> Identity Açıp (Yandaki + ile)==> Is Identity True Yap
    //Bütün satırların zorunlu olması için Allow Nulls Tikini Kaldır.
    //Altan Desing Kısmından CREATE TABLE [dbo].[Producst] El ile İsmini değiştir.
    //Son Olarak Hemen Üste Update Seçeneğine Tıkla

    //Tablo' Veriye Eklemek İçin Sol Menüde (SQL Server Object Explorer) (localdb)\MSSQL..... ==> Databases ==> ETRade ==> Tables ==> dbo.Product Sağ Tıkla ve View Data De
    //Cloum'lara veriyi el ile gir.

    //Dal ==£ Data Acces Layer
    //İlk Harf büyük, diğerleri küçük. Kelimelere Pascal Case Denir.

    //Verinin TextBox'larda Kontrollünü Validation ile Sağlanır. ==>
    #endregion
}
