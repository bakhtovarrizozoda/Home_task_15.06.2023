using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeAddressController
{
    private readonly EmployeeAdddresseService _employeeAdddresseService;


    public EmployeeAddressController(EmployeeAdddresseService employeeAdddresseService)
    {
        _employeeAdddresseService = employeeAdddresseService;
    }

    [HttpGet("GetEmployeeAddress")]
    public async Task<List<GetEmployeeAdddresseDto>> GetEmployeeAddress()
    {
        return await _employeeAdddresseService.GetEmployeeAddress();
    }

    [HttpGet("GetById")]
    public async Task<GetEmployeeAdddresseDto?> GetEmployeeAddressById(int id)
    {
        return await _employeeAdddresseService.GetEmployeeAddressById(id);
    }

    [HttpPost("AddEmployeeAddress")]
    public async Task<AddEmployeeAdddresseDto> AddEmployeeAddress(AddEmployeeAdddresseDto modul)
    {
        return await _employeeAdddresseService.AddEmployeeAddress(modul);
    }

    [HttpPut("UpdateEmployeeAddress")]
    public async Task<AddEmployeeAdddresseDto> UpdateAddEmployee(AddEmployeeAdddresseDto modul)
    {
        return await _employeeAdddresseService.UpdateAddEmployee(modul);
    }

    [HttpDelete("Delete")]
    public async Task<bool> DeleteAddEmployeeAddress(int id)
    {
        return await _employeeAdddresseService.DeleteAddEmployeeAddress(id);
    }
}