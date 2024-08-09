using Application.Bases;

namespace Application.Features.Categories.Exception
{
    public class CategoryNameMustNotBeSameException:BaseException
    {
        public CategoryNameMustNotBeSameException() : base("Aynı kategori ismine sahip kayıt bulunuyor!") { }
    }
}
