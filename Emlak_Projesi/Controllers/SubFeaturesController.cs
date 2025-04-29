using Emlak_Projesi.Repositories.SubFeatureRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeaturesController : ControllerBase
    {
        private readonly ISubFeaturesRepository _subFeaturesRepository;

        public SubFeaturesController(ISubFeaturesRepository subFeaturesRepository)
        {
            _subFeaturesRepository = subFeaturesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubFeatureList()
        {
            var values = await _subFeaturesRepository.GetAllSubFeatureAsync();
            return Ok(values); 
        }
    }
}
