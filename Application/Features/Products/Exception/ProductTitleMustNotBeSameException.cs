using Application.Bases;

namespace Application.Features.Products.Exception
{
    public class ProductTitleMustNotBeSameException:BaseException
    {
        public ProductTitleMustNotBeSameException() : base("Aynı ürün başlığına sahip kayıt bulunmaktadır.") { }
    }
}
