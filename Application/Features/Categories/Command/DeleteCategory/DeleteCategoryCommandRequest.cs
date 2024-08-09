using MediatR;

namespace Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
