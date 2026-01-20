using System.Collections.Generic;
using UniversityCourse.Models;

namespace UniversityCourse;

public class Course<T> where T : CourseType
{
    public string Code { get; set; }
    public T Evaluation { get; set; }
    private readonly List<string> submissions = new();

    public Course(string code, T evaluation)
    {
        Code = code;
        Evaluation = evaluation;
    }

    public void AddSubmission(string submission) => submissions.Add(submission);

    public void RunEvaluations()
    {
        foreach (var s in submissions)
            Console.WriteLine(Evaluation.Evaluate(s));
    }
}
