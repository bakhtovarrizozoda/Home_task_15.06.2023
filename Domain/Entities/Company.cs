using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Company
{
    public Company()
    {
        
    }
    public Company(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }
}

