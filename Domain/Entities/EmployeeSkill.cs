namespace Domain.Entities;

public class EmployeeSkill
{
    public EmployeeSkill()
    {
        
    }
    public EmployeeSkill(int modulEmployeeId, int modulSkillId)
    {
        EmployeeId = modulEmployeeId;
        SkillId = modulSkillId;
    }

    public int SkillId { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employees { get; set; }
    public Skill Skills { get; set; }
}