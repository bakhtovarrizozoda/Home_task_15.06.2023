using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeAdddresseService
{
    private readonly DataContext _context;

    public EmployeeAdddresseService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetEmployeeAdddresseDto>> GetEmployeeAddress()
    {
        return await _context.EmployeeAdddresses.Select(e => new GetEmployeeAdddresseDto()
        {
            Id = e.Id,
            Address = e.Address,
            EmployeeId = e.EmployeeId,
            Employees = e.Employees.Name
        }).ToListAsync();
    }

    public async Task<GetEmployeeAdddresseDto?> GetEmployeeAddressById(int id)
    {
        return await _context.EmployeeAdddresses.Select(e => new GetEmployeeAdddresseDto()
        {
            Id = e.Id,
            Address = e.Address,
            EmployeeId = e.EmployeeId,
            Employees = e.Employees.Name
        }).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<AddEmployeeAdddresseDto> AddEmployeeAddress(AddEmployeeAdddresseDto modul)
    {
        var address = new EmployeeAdddresse(modul.Address, modul.EmployeeId);
        await _context.EmployeeAdddresses.AddAsync(address);
        await _context.SaveChangesAsync();
        return modul;
    }

    public async Task<AddEmployeeAdddresseDto> UpdateAddEmployee(AddEmployeeAdddresseDto modul)
    {
        var find = await _context.EmployeeAdddresses.FindAsync(modul.Id);
        find.Id = modul.Id;
        find.Address = modul.Address;
        find.EmployeeId = modul.EmployeeId;
        await _context.SaveChangesAsync();
        return modul;
    }

    public async Task<bool> DeleteAddEmployeeAddress(int id)
    {
        var find = await _context.EmployeeAdddresses.FindAsync(id);
        _context.EmployeeAdddresses.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

}
