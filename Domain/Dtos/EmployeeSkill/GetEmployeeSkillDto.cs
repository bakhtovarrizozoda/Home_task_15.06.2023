namespace Domain.Entities;

public class GetEmployeeSkillDto : EmployeeSkillBaseDto
{
    public string Employees { get; set; }
    public string Skills { get; set; }
}