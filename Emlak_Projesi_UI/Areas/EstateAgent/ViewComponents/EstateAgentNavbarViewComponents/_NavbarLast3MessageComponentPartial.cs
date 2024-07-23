using Emlak_Projesi_UI.Dto.MessageDtos;
using Emlak_Projesi_UI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak_Projesi_UI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarViewComponents
{
    public class _NavbarLast3MessageComponentPartial : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly ILoginService _loginService;

        public _NavbarLast3MessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7099/api/Messages?id=" + id);
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
