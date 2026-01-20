namespace UniversityCourse.Models;

public abstract class CourseType
{
    public abstract string TypeName { get; }
    public abstract string Evaluate(string submission);
}

public class ExamCourse : CourseType
{
    public override string TypeName => "Exam";
    public override string Evaluate(string submission) => $"Exam graded for: {submission}";
}

public class AssignmentCourse : CourseType
{
    public override string TypeName => "Assignment";
    public override string Evaluate(string submission) => $"Assignment reviewed for: {submission}";
}
