using Application.Bases;
using Application.Features.Categories.Exception;
using Domain.Entities;

namespace Application.Features.Categories.Rules
{
    public class CategoryRules:BaseRules
    {
        public Task CategoryNameMustNotBeSame(IList<Category> categories, string requestTitle)
        {
            if (categories.Any(x => x.Name== requestTitle)) throw new CategoryNameMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
