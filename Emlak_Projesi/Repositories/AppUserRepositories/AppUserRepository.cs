using Dapper;
using Emlak_Projesi.Dtos.AppUserDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetAppUserByProductDto> GetAppUserByProductId(int id)
        {
            string query = "Select * From AppUser Where UserId=@UserId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@UserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductDto>(query, paramaters);
                return values;
            }
        }
    }
}
