namespace Domain.Entities;

public class EmployeeAdddresse
{
    public EmployeeAdddresse()
    {
        
    }
    public EmployeeAdddresse( string address, int employeeId)
    {
        Address = address;
        EmployeeId = employeeId;
    }

    public int Id { get; set; }
    public string Address { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employees { get; set; }
}