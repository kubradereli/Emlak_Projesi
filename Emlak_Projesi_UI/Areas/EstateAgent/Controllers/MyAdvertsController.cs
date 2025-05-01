using Emlak_Projesi_UI.Dto.CategoryDtos;
using Emlak_Projesi_UI.Dto.ProductDtos;
using Emlak_Projesi_UI.Models;
using Emlak_Projesi_UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Emlak_Projesi_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly ILoginService _loginService;
        private readonly ApiSettings _apiSettings;

        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> ActiveAdverts()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Products/ProductAdvertsListByEmployeeIdByTrue?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PassiveAdverts()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Products/ProductAdvertsListByEmployeeIdByFalse?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdvert()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.v = categoryValues;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreateProductDto createProductDto)
        {
            createProductDto.DealOfTheDay = false;
            createProductDto.AdvertisementDate = DateTime.Now;
            createProductDto.ProductStatus = true;

            var id = _loginService.GetUserId;
            createProductDto.EmployeeID = int.Parse(id);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
