using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CompanyService
{
    private readonly DataContext _context;

    public CompanyService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<CompanyBaseDto>> GetCompany()
    {
        return await _context.Companies.Select(e=>new CompanyBaseDto()
        {
            Id = e.Id,
            Name = e.Name
        }).ToListAsync();
    }

    public async Task<CompanyBaseDto?> GetCompanyById(int id)
    {
        return await _context.Companies.Select(e => new CompanyBaseDto()
        {
            Id = e.Id,
            Name = e.Name
        }).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<CompanyBaseDto> AddCompany(CompanyBaseDto modul)
    {
        var company = new Company(modul.Name);
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
        modul.Id = company.Id;
        return modul;
    }

    public async Task<CompanyBaseDto> UpdateCompany(CompanyBaseDto modul)
    {
        var find = await _context.Companies.FindAsync(modul.Id);
        find.Id = modul.Id;
        find.Name = modul.Name;
        await _context.SaveChangesAsync();
        return modul;
    }

    public async Task<bool> DeleteCompany(int id)
    {
        var find = await _context.Companies.FindAsync(id);
        _context.Companies.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
}