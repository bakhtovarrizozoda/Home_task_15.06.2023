using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("GetEmployee")]
    public async Task<List<GetEmployeeDto>> GetEmployees()
    {
        return await _employeeService.GetEmployees();
    }

    [HttpGet("GetById")]
    public async Task<GetEmployeeDto?> GetEmployeeById(int id)
    {
        return await _employeeService.GetEmployeeById(id);
    }

    [HttpPost("AddEmployee")]
    public async Task<AddEmployeeDto> AddEmployee(AddEmployeeDto modul)
    {
        return await _employeeService.AddEmployee(modul);
    }

    [HttpPut("UpdateEmployee")]
    public async Task<AddEmployeeDto> UpdateEmployee(AddEmployeeDto modul)
    {
        return await _employeeService.UpdateEmployee(modul);
    }

    [HttpDelete("DeleteEmployee")]
    public async Task<bool> DeleteEmployee(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }
}