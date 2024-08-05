using Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Exception
{
    public class ProductTitleMustNotBeSameException:BaseException
    {
        public ProductTitleMustNotBeSameException() : base("Aynı ürün başlığına sahip kayıt bulunmaktadır.") { }
    }
}
