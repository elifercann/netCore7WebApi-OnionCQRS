using MediatR;
using Domain.Entities;
using Application.Interfaces.UnitOfWorks;
using Application.Interfaces.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include:x=>x.Include(q=>q.Brand));

            var brand=mapper.Map<BrandDto,Brand>(new Brand());

            var map=mapper.Map<GetAllProductsQueryResponse,Product>(products);

            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);
            return map;
        }
    }
}
