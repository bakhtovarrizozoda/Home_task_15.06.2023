using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeSkillService
{
    private readonly DataContext _context;

    public EmployeeSkillService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetEmployeeSkillDto>> GetEmployeeSkill()
    {
        return await _context.EmployeeSkills.Select(e=>new GetEmployeeSkillDto()
        {
            EmployeeId = e.EmployeeId,
            SkillId = e.SkillId
        }).ToListAsync();
    }

    public async Task<AddEmployeeSkillDto> AddEmployeeSkill(AddEmployeeSkillDto modul)
    {
        var employeskil = new EmployeeSkill(modul.EmployeeId, modul.SkillId);
        await _context.EmployeeSkills.AddAsync(employeskil);
        await _context.SaveChangesAsync();
        return modul;
    }

    public async Task<AddEmployeeSkillDto> UpdateEmployeeSkill(AddEmployeeSkillDto modul)
    {
        var find = await _context.EmployeeSkills.FindAsync(modul.EmployeeId);
        find.SkillId = modul.EmployeeId;
        find.SkillId = modul.SkillId;
        await _context.SaveChangesAsync();
        return modul;
    }

    public async Task<bool> DeleteEmployeSkill(int id)
    {
        var find = await _context.EmployeeSkills.FindAsync(id);
        _context.EmployeeSkills.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

}