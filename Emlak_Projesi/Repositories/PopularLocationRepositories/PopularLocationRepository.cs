using Dapper;
using Emlak_Projesi.Dtos.PopularLocationDtos;
using Emlak_Projesi.Dtos.ServiceDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation (CityName, ImageUrl) values (@cityName, @imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", createPopularLocationDto.CityName);
            parameters.Add("@imageUrl", createPopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocation Where PopularLocationID=@popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDPopularLocationDto> GetPopularLocation(int id)
        {
            string query = "Select * From PopularLocation Where PopularLocationID=@popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetByIDPopularLocationDto>(query, parameters);
                return values;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update PopularLocation Set CityName=@cityName, ImageUrl=@imageUrl where PopularLocationID=@popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", updatePopularLocationDto.PopularLocationID);
            parameters.Add("@cityName", updatePopularLocationDto.CityName);
            parameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
