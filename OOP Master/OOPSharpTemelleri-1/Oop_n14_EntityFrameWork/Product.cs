using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Oop_n14_EntityFrameWork
{
    //Pascal Case ==> İsimlenmdirme kurallarına Dikkat Et.
    //Contex == Unit Of Work Desing Patters //Bakılacak
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
