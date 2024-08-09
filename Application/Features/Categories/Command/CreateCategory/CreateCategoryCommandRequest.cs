using MediatR;

namespace Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandRequest:IRequest<Unit>
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priorty { get; set; }
        public IList<int> DetailIds { get; set; }
        public IList<int> ProductIds { get; set; }
    }
}
