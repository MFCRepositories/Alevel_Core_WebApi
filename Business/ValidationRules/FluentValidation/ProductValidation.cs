using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidation
        : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün İsmi Boş Geçilemez");
            RuleFor(x => x.Name).Length(2,6);
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori Boş Geçilemez");
            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Tedarikçi Boş Geçilemez");
        }
    }
}
