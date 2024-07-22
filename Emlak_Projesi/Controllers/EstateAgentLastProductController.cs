using Emlak_Projesi.Repositories.EstateAgentRepositories.DasboardRepositories.LastProductsRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductController : ControllerBase
    {
        private readonly ILastProductsRepository _lastProductsRepository;

        public EstateAgentLastProductController(ILastProductsRepository lastProductsRepository)
        {
            _lastProductsRepository = lastProductsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLast5ProductAsync(int id)
        {
            var values = await _lastProductsRepository.GetLast5ProductAsync(id);
            return Ok(values);
        }
    }
}
