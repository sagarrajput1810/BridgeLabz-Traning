using UniversityCourse.Models;

class Program
{
    static void Main()
    {
        var examCourse = new Course<ExamCourse>("CS101", new ExamCourse());
        examCourse.AddSubmission("StudentA Submission");
        examCourse.RunEvaluations();

        var assignCourse = new Course<AssignmentCourse>("ENG201", new AssignmentCourse());
        assignCourse.AddSubmission("StudentB Essay");
        assignCourse.RunEvaluations();
    }
}
