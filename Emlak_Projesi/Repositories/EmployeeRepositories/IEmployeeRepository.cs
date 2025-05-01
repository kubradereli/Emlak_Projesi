using Emlak_Projesi.Dtos.EmployeeDtos;

namespace Emlak_Projesi.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployee();

        Task CreateEmployee(CreateEmployeeDto createEmployeeDto);

        Task DeleteEmployee(int id);

        Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);

        Task<GetByIDEmployeeDto> GetEmployee(int id);
    }
}
