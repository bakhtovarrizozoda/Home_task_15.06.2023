using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class SkillService
{
    private readonly DataContext _context;

    public SkillService(DataContext  context)
    {
        _context = context;
    }

    public async Task<List<SkillBaseDto>> GetSkill()
    {
        return await _context.Skills.Select(e=>new SkillBaseDto()
        {
            Id = e.Id,
            SkillName = e.SkillName
        }).ToListAsync();
    }

    public async Task<SkillBaseDto?> GetSkillById(int id)
    {
        return await _context.Skills.Select(e => new SkillBaseDto()
        {
            Id = e.Id,
            SkillName = e.SkillName
        }).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<SkillBaseDto> AddSkill(SkillBaseDto modul)
    {
        var skill = new Skill(modul.SkillName);
        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();
        return modul;
    }

    public async Task<SkillBaseDto> UpdateSkill(SkillBaseDto modul)
    {
        var find = await _context.Skills.FindAsync(modul.Id);
        find.Id = modul.Id;
        find.SkillName = modul.SkillName;
        await _context.SaveChangesAsync();
        return modul;
    }

    public async Task<bool> DeleteSkill(int id)
    {
        var find = await _context.Skills.FindAsync(id);
        _context.Skills.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
}