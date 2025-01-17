﻿using Emlak_Projesi.Dtos.EmployeeDtos;

namespace Emlak_Projesi.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();

        void CreateEmployee(CreateEmployeeDto createEmployeeDto);

        void DeleteEmployee(int id);

        void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);

        Task<GetByIDEmployeeDto> GetEmployee(int id);
    }
}
