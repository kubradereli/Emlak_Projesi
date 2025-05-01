using Emlak_Projesi_UI.Dto.ProductDetailDtos;
using Emlak_Projesi_UI.Dto.ProductDtos;
using Emlak_Projesi_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Emlak_Projesi_UI.Controllers
{
    public class PropertyController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public PropertyController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
            city = TempData["city"].ToString();
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync($"Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug, int id)
        {
            ViewBag.i = id;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Products/GetProductByProductId?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

            var client2 = _httpClientFactory.CreateClient();
            client2.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage2 = await client2.GetAsync("ProductDetails/GetProductDetailByProductId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);

            ViewBag.productid = values.productID;
            ViewBag.title1 = values.title;
            ViewBag.price = values.price;
            ViewBag.city = values.city;
            ViewBag.district = values.district;
            ViewBag.address = values.address;
            ViewBag.type = values.type;
            ViewBag.description = values.description;
            ViewBag.date = values.AdvertisementDate.ToString("dd-MMM-yyyy");
            ViewBag.slugUrl = values.slugUrl;

            ViewBag.bathcount = values2.BathCount;
            ViewBag.bedcount = values2.BedRoomCount;
            ViewBag.size = values2.ProductSize;
            ViewBag.roomCount = values2.RoomCount;
            ViewBag.garageCount = values2.GarageSize;
            ViewBag.buildYear = values2.BuildYear;
            ViewBag.location = values2.Location;
            ViewBag.videoUrl = values2.VideoUrl;

            DateTime date1 = DateTime.Now;
            DateTime date2 = values.AdvertisementDate;

            TimeSpan timeSpan = date1 - date2;
            int month = timeSpan.Days;

            ViewBag.datediff = month / 30;

            string slugFromTitle = CreateSlug(values.title);
            ViewBag.slug = slugFromTitle;

            return View();
        }

        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant();
            title = title.Replace(" ", "-");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", "");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim();
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-");
            return title;
        }
    }
}
