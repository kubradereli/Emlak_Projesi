using Dapper;
using Emlak_Projesi.Dtos.ServiceDtos;
using Emlak_Projesi.Models.DapperContext;

namespace Emlak_Projesi.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateService(CreateServiceDto serviceDto)
        {
            string query = "insert into Service (ServiceName, ServiceStatus) values (@serviceName, @serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", serviceDto.ServiceName);
            parameters.Add("@serviceStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteService(int id)
        {
            string query = "Delete From Service Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllService()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDServiceDto> GetService(int id)
        {
            string query = "Select * From Service Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateService(UpdateServiceDto updateServiceDto)
        {
            string query = "Update Service Set ServiceName=@serviceName, ServiceStatus=@serviceStatus where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", updateServiceDto.ServiceID);
            parameters.Add("@serviceName", updateServiceDto.ServiceName);
            parameters.Add("@serviceStatus", updateServiceDto.ServiceStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
