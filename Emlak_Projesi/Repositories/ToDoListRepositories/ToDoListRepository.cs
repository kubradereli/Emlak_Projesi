using Dapper;
using Emlak_Projesi.Dtos.ToDoListDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public Task CreateToDoList(CreateToDoListDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoList()
        {
            string query = "Select * From ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public Task<GetBYIDToDoListDto> GetToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoList(UpdateToDoListDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
