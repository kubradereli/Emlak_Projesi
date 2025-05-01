using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Emlak_Projesi_UI.Dto.WhoWeAreDtos;
using Emlak_Projesi_UI.Dto.ServiceDtos;
using Emlak_Projesi_UI.Models;
using Microsoft.Extensions.Options;

namespace Emlak_Projesi_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var client2 = _httpClientFactory.CreateClient();
            client2.BaseAddress = new Uri(_apiSettings.BaseUrl);

            var responseMessage = await client.GetAsync("WhoWeAreDetail");
            var responseMessage2 = await client2.GetAsync("Sevices");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);

                ViewBag.title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.subtitle = value.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.description2 = value.Select(x => x.Description2).FirstOrDefault();
                return View(value2);
            }
            return View();
        }
    }
}
