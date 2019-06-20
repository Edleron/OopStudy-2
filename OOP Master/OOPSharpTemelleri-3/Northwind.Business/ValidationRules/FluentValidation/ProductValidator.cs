using FluentValidation;
using Northwind.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //Fluent Validation Dökümantasyonuna Bakılacak
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün İsmi Bol Olamaz");// Ürün İsmi Gİrmen Gerekiyor. ve Uyarı Verdirdik.
            //Uyarı Mesajları Bölgeseldir. 19 dilde destek verir.
            RuleFor(p => p.CategoryId).NotEmpty();// Girmen Gerekiyor Boş Geçilemez
            RuleFor(p => p.UnitPrice).NotEmpty();// Girmen Gerekiyor Boş Geçilemez 
            RuleFor(p => p.QuantityPerUnit).NotEmpty();// Girmen Gerekiyor Boş Geçilemez 
            RuleFor(p => p.UnitsInStock).NotEmpty();// Girmen Gerekiyor Boş Geçilemez 

            RuleFor(p => p.UnitPrice).GreaterThan(0);// 0'dan Büyük Olmalıdır.
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);// Ürün Stokta yok tedarik edebilirsiniz.
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);// Kategory Id 2 olduğunda Unit Price 10'dan büyük olmalıdır.

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün Adı A ile Başlamalıdır.");//Kendi Validator Kodumuzu Yazdık. ProductName'ler A ile Başlamalıdır.

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("");
        }
    }
}
