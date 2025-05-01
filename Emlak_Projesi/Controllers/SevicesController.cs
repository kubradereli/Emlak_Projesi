using Emlak_Projesi.Dtos.ServiceDtos;
using Emlak_Projesi.Repositories.ServiceRepository;
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
            var value = await _serviceRepository.GetAllService();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceRepository.CreateService(createServiceDto);
            return Ok("Hizmet kısmı başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceRepository.DeleteService(id);
            return Ok("Hizmet kısmı başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceRepository.UpdateService(updateServiceDto);
            return Ok("Hizmet kısmı başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _serviceRepository.GetService(id);
            return Ok(value);
        }
    }
}
