using Dapper;
using Emlak_Projesi.Dtos.BottomGridDtos;
using Emlak_Projesi.Dtos.ServiceDtos;
using Emlak_Projesi.Models.DapperContext;
using Emlak_Projesi.Repositories.BottomGridRepository;

namespace Emlak_Projesi.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Icon, Title, Description) values (@icon, @title, @description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", createBottomGridDto.Icon);
            parameters.Add("@title", createBottomGridDto.Title);
            parameters.Add("@description", createBottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "Update BottomGrid Set Icon=@icon, Title=@title, Description=@description Where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", updateBottomGridDto.BottomGridID);
            parameters.Add("@icon", updateBottomGridDto.Icon);
            parameters.Add("@title", updateBottomGridDto.Title);
            parameters.Add("@description", updateBottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
