using Emlak_Projesi.Repositories.ServiceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SevicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public SevicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }
    }
}
