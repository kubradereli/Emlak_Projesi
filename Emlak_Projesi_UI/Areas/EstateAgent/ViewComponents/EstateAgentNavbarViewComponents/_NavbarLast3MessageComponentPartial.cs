using Emlak_Projesi_UI.Dto.MessageDtos;
using Emlak_Projesi_UI.Models;
using Emlak_Projesi_UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Emlak_Projesi_UI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarViewComponents
{
    public class _NavbarLast3MessageComponentPartial : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly ILoginService _loginService;
        private readonly ApiSettings _apiSettings;

        public _NavbarLast3MessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("Messages?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
