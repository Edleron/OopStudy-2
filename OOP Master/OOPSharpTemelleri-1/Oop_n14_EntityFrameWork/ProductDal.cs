using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop_n14_EntityFrameWork
{
    public class ProductDal
    {
        #region GetAll
        public List<Product> GetAll()
        {
            //Veritabanı Sorgu atmak
            //Daha Performanslıdır.

            //Bütün Veritabanı Listesi 
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
            }
        }

        public List<Product> GetByName(string key)
        {
            //Veritabanı Sorgu atmak
            //Daha Performanslıdır.

            //Search Name LİNQ
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }

        public List<Product> GetByUnitPrice(decimal price)
        {
            //Veritabanı Sorgu atmak
            //Daha Performanslıdır.

            //Fiyata Göre Arama LİNQ
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
            }
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            //Veritabanı Sorgu atmak
            //Daha Performanslıdır.

            //İki Fiyat Aralığa Göre Arama LİNQ
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
            }
        }

        public Product GetByID(int id)
        {
            //Veritabanı Sorgu atmak
            //Daha Performanslıdır.

            //ID'e Göre Arama LİNQ
            using (ETradeContext context = new ETradeContext())
            {
                //Data Bulamaz ise null döner
                //Data Bulur ise Datanın Kendisini Döner

                //Bu hata Fırlatmaz
                var result = context.Products.FirstOrDefault(p=>p.Id == id);

                //Bu hata Fırlatır
                //var result = context.Products.SingleOrDefault(p => p.Id == id);
                return result;
            }
        }
        #endregion

        #region Add
        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //İki kod'da Çalışır
                //context.Products.Add(product);
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        #endregion

        #region Update
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion

        #region Deleted
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        #endregion
    }
}
