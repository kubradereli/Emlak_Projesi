using Dapper;
using Emlak_Projesi.Dtos.LoginDtos;
using Emlak_Projesi.Models.DapperContext;
using Emlak_Projesi.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            string query = "Select * From AppUser Where UserName=@username and Password=@password";
            string query2 = "Select UserID From AppUser Where UserName=@username and Password=@password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", loginDto.Username);
            parameters.Add("@password", loginDto.Password);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                var values2 = await connection.QueryFirstAsync<GetAppUserIdDto>(query2, parameters);
                
                if (values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.Username = values.Username;
                    model.ID = values2.UserID;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
