using Blazor.FurnitureStore.Repositories.Interfaces;
using Blazor.FurnitureStore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.FurnitureStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryController(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategory>> Get()
        {
            var list = await _repository.GetAll();

            return list;
        }
    }
}
