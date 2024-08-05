using MediatR;

namespace Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
