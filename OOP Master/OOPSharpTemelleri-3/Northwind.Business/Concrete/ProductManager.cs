using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    //Burada İş Katmanı Kodlaması Yapılır.
    public class ProductManager : IProductService
    {
        #region Property
        //EfProductDal _productDal = new EfProductDal();
        private IProductDal _productDal;
        #endregion



        #region Constructors
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        #endregion


        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
        }


        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch
            {
                throw new Exception("Silme İşlemi Gerçekleştirilemedi");
            }

        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }

        public List<Product> GetAll()
        {
            //Busines Code

            return _productDal.GetAll();
            //Depensiy oluştuğu için kullanılmaz.
        }

        public List<Product> GetProductsByCategory(int categoryID)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryID);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            //To Lover Küçük-Büyük Harf Uyumu Çevirir.
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }        
    }
}
