namespace ResumeScreening.Models;

public abstract class JobRole
{
    public string RoleName { get; set; }
    protected JobRole(string name) { RoleName = name; }
    public abstract bool Matches(ResumeData data);
}

public class SoftwareEngineer : JobRole
{
    public SoftwareEngineer() : base("Software Engineer") { }
    public override bool Matches(ResumeData data) => data.HasSkill("C#") || data.HasSkill("DotNet");
}

public class DataScientist : JobRole
{
    public DataScientist() : base("Data Scientist") { }
    public override bool Matches(ResumeData data) => data.HasSkill("Python") || data.HasSkill("ML");
}

public record ResumeData(string Name, string[] Skills)
{
    public bool HasSkill(string skill) => Skills.Contains(skill, StringComparer.OrdinalIgnoreCase);
}
