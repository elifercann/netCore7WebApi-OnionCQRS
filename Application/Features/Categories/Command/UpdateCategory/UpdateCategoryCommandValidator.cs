using FluentValidation;

namespace Application.Features.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.ParentId)
    .NotEmpty()
    .WithName("Eklenen üst modül");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithName("Kategori Adı");

            RuleFor(x => x.Priorty)
                .GreaterThan(0)
                .WithName("Öncelik");

            //RuleFor(x => x.DetailIds)
            //    .NotEmpty()
            //    .Must(details => details.Any())
            //    .WithName("Detaylar");

            RuleFor(x => x.ProductIds)
            .NotEmpty()
            .Must(products => products.Any())
            .WithName("Ürünler");
        }
    }
}
