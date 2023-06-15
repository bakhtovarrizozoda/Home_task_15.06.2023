using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("GetCompany")]
    public async Task<List<CompanyBaseDto>> GetCompany()
    {
        return await _companyService.GetCompany();
    }

    [HttpGet("GetById")]
    public async Task<CompanyBaseDto?> GetCompanyById(int id)
    {
        return await _companyService.GetCompanyById(id);
    }

    [HttpPost("AddCompany")]
    public async Task<CompanyBaseDto> AddCompany(CompanyBaseDto modul)
    {
        return await _companyService.AddCompany(modul);
    }

    [HttpPut("UpdateCompany")]
    public async Task<CompanyBaseDto> UpdateCompany(CompanyBaseDto modul)
    {
        return await _companyService.UpdateCompany(modul);
    }

    [HttpDelete("DeleteCompany")]
    public async Task<bool> DeleteCompany(int id)
    {
        return await _companyService.DeleteCompany(id);
    }
}