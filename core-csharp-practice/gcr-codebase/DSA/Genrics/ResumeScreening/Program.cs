using ResumeScreening.Models;

class Program
{
    static void Main()
    {
        var resumeData = new ResumeData("Alice", new[] { "C#", "SQL" });
        var resume = new Resume<SoftwareEngineer>(resumeData);

        var role = new SoftwareEngineer();
        Console.WriteLine($"Does {resumeData.Name} match {role.RoleName}? {resume.Screen(role)}");
    }
}
