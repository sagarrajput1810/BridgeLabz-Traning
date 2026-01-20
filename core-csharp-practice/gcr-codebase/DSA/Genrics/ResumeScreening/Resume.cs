using ResumeScreening.Models;

namespace ResumeScreening;

public class Resume<T> where T : JobRole
{
    public ResumeData Data { get; set; }

    public Resume(ResumeData data) => Data = data;

    public bool Screen(T role) => role.Matches(Data);
}
