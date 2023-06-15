using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeSkilController
{
    private readonly EmployeeSkillService _employeeSkillService;

    public EmployeeSkilController(EmployeeSkillService employeeSkillService)
    {
        _employeeSkillService = employeeSkillService;
    }

    [HttpGet("GetEmployeeSkill")]
    public async Task<List<GetEmployeeSkillDto>> GetEmployeeSkill()
    {
        return await _employeeSkillService.GetEmployeeSkill();
    }

    [HttpPost("AddEmployeeSkill")]
    public async Task<AddEmployeeSkillDto> AddEmployeeSkill(AddEmployeeSkillDto modul)
    {
        return await _employeeSkillService.AddEmployeeSkill(modul);
    }

    [HttpPut("Update")]
    public async Task<AddEmployeeSkillDto> UpdateEmployeeSkill(AddEmployeeSkillDto modul)
    {
        return await _employeeSkillService.UpdateEmployeeSkill(modul);
    }

    [HttpDelete("Delete")]
    public async Task<bool> DeleteEmployeSkill(int id)
    {
        return await _employeeSkillService.DeleteEmployeSkill(id);
    }
}