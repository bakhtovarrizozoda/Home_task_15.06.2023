namespace Domain.Entities;

public class Skill
{
    public Skill(string skillName)
    {
        SkillName = skillName;
    }

    public int Id { get; set; }
    public string SkillName { get; set; }
    public List<EmployeeSkill> EmployeeSkills { get; set; }
}