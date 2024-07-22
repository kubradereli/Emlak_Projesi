using Emlak_Projesi_UI.Dto.EstateAgentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak_Projesi_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardChartComponentPartial : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashboardChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7099/api/EstateAgentChart");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateAgentDashboardChartDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
