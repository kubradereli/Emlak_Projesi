using Emlak_Projesi.Dtos.EmployeeDtos;
using Emlak_Projesi.Repositories.EmployeeRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak_Projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var values = await _employeeRepository.GetAllEmployee();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            await _employeeRepository.CreateEmployee(createEmployeeDto);
            return Ok("Personel başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok("Personel başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Personel başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var value = await _employeeRepository.GetEmployee(id);
            return Ok(value);

        }
    }
}