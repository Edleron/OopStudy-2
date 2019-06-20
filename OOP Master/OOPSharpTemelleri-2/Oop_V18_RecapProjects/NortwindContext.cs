using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Oop_V18_RecapProjects.Entites;

namespace Oop_V18_RecapProjects
{
    //Bunun bir Context olabilmesi için Entity FrameWork'un DbContext İnherit alınması gerekir.
    public class NortwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
