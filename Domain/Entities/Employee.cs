using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee
{
    public Employee()
    {
        
    }
    public Employee( string name, int companyId)
    {
        Name = name;
        CompanyId = companyId;
    }

    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public int CompanyId { get; set; }
    public Company Companies { get; set; }
    public List<EmployeeAdddresse> EmployeeAdddresses { get; set; }
    public List<EmployeeSkill> EmployeeSkills { get; set; }
}