using Dapper;
using Emlak_Projesi.Dtos.ChartDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.EstateAgentRepositories.DasboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDto>> Get5CityForChart()
        {
            string query = "Select Top(5) City, Count(*) as 'CityCount' From Product Group By City Order By CityCount Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDto>(query);
                return values.ToList();
            }
        }
    }
}
