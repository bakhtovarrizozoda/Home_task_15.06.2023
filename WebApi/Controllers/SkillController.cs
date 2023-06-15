using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class SkillController
{
    private readonly SkillService _skillService;

    public SkillController(SkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet("GetSkill")]
    public async Task<List<SkillBaseDto>> GetSkill()
    {
        return await _skillService.GetSkill();
    }

    [HttpGet("GetById")]
    public async Task<SkillBaseDto?> GetSkill(int id)
    {
        return await _skillService.GetSkillById(id);
    }

    [HttpPost("AddSkill")]
    public async Task<SkillBaseDto> AddSkill(SkillBaseDto modul)
    {
        return await _skillService.AddSkill(modul);
    }

    [HttpPut("UpdateSkill")]
    public async Task<SkillBaseDto> UpdateSkill(SkillBaseDto modul)
    {
        return await _skillService.UpdateSkill(modul);
    }

    [HttpDelete("DeleteSkill")]
    public async Task<bool> DeleteSkill(int id)
    {
        return await _skillService.DeleteSkill(id);
    }
}