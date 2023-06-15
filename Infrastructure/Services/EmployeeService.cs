using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetEmployeeDto>> GetEmployees()
    {
        return await _context.Employees.Select(e=>new GetEmployeeDto()
        {
            Id = e.Id,
            Name = e.Name,
            CompanyId = e.CompanyId,
            Companies = e.Companies.Name
        }).ToListAsync();
    }

    public async Task<GetEmployeeDto?> GetEmployeeById(int id)
    {
        return await _context.Employees.Select(e => new GetEmployeeDto()
        {
            Id = e.Id,
            Name = e.Name,
            CompanyId = e.CompanyId,
            Companies = e.Companies.Name
        }).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<AddEmployeeDto> AddEmployee(AddEmployeeDto modul)
    {
        var employee = new Employee(modul.Name, modul.CompanyId);
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return modul;
    }

    public async Task<AddEmployeeDto> UpdateEmployee(AddEmployeeDto modul)
    {
        var find = await _context.Employees.FindAsync(modul.Id);
        find.Id = modul.Id;
        find.Name = modul.Name;
        find.CompanyId = modul.CompanyId;
        await _context.SaveChangesAsync();
        return modul;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var find = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
}