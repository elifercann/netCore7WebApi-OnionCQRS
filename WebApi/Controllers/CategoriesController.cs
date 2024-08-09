using Application.Features.Categories.Command.CreateCategory;
using Application.Features.Categories.Command.DeleteCategory;
using Application.Features.Categories.Command.UpdateCategory;
using Application.Features.Categories.Queries.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator; 
        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await mediator.Send(new GetAllCategoriesQueryRequest());

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
