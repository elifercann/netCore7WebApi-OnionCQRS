using Application.Bases;
using Application.Features.Categories.Rules;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.UnitOfWorks;
using Bogus.DataSets;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : BaseHandler, IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly CategoryRules categoryRules;

        public CreateCategoryCommandHandler(CategoryRules categoryRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.categoryRules = categoryRules;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories=await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            await categoryRules.CategoryNameMustNotBeSame(categories, request.Name);

            Category category = new(request.ParentId, request.Name, request.Priorty);

            await unitOfWork.GetWriteRepository<Category>().AddAsync(category);
            if (await unitOfWork.SaveAsync()>0)
            {
                foreach (var productsId in request.ProductIds)
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId=productsId,
                        CategoryId=category.Id,

                    });

                await unitOfWork.SaveAsync();
                
            }
            return Unit.Value;
        }
    }
}
