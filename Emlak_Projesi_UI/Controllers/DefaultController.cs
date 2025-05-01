using Emlak_Projesi_UI.Dto.CategoryDtos;
using Emlak_Projesi_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Emlak_Projesi_UI.Controllers
{
    public class DefaultController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public DefaultController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> PartialSearch()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return PartialView(values);
            }
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
            TempData["searchKeyValue"] = searchKeyValue;
            TempData["propertyCategoryId"] = propertyCategoryId;
            TempData["city"] = city;
            return RedirectToAction("PropertyListWithSearch", "Property");
        }
    }
}
