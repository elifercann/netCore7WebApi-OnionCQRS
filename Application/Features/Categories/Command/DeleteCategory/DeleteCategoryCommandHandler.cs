using Application.Bases;
using Application.Interfaces.AutoMapper;
using Application.Interfaces.UnitOfWorks;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : BaseHandler, IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        public DeleteCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category=await unitOfWork.GetReadRepository<Category>().GetAsync(x=>x.Id == request.Id && !x.IsDeleted);
            category.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();

            return Unit.Value;

        }
    }
}
