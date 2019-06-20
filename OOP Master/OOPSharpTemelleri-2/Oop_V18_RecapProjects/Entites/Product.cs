using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop_V18_RecapProjects.Entites
{
    //Veritabamında bir listeyi tuttuğu için Product, Ama Burada Classta tekil işlerde kullanacağımız için Product diye kullandık.
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public string QuanTityPerUnit { get; set; }
    }
}
