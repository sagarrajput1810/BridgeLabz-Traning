using System;

class Course
{
    public string CourseName;
    public int Duration;
}

class OnlineCourse : Course
{
    public string Platform;
    public bool IsRecorded;
}

class PaidOnlineCourse : OnlineCourse
{
    public double Fee;
    public double Discount;
}

class CourseTest
{
    static void Main()
    {
        PaidOnlineCourse c = new PaidOnlineCourse();
        c.CourseName = "C# Mastery";
        c.Duration = 30;
        c.Platform = "Udemy";
        c.IsRecorded = true;
        c.Fee = 5000;
        c.Discount = 500;

        Console.WriteLine("Course Name: " + c.CourseName);
        Console.WriteLine("Fee: " + c.Fee);
    }
}
