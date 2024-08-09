using MediatR;

namespace Application.Features.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priorty { get; set; }
        public IList<int> DetailIds { get; set; }
        public IList<int> ProductIds { get; set; }
    }
}
