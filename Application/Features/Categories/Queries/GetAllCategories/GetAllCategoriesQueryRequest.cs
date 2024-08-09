using Application.Interfaces.RedisCache;
using MediatR;

namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : IRequest<IList<GetAllCategoriesQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllCategories";

        public double CacheTime => 60;
    }
}
