using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop_n14_EntityFrameWork
{
    //Contex == Unit Of Work Desing Patters //Bakılacak

    //Temel anlamda context oluşturma kodları aşağıdadır.
    public class ETradeContext : DbContext
    {
        //Tablolarda Products'ı arar
        public DbSet<Product> Products { get; set; }

    }
}
