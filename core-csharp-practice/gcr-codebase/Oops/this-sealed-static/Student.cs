using System;

class Student
{
    public static string universityName;
    private static int totalStudents = 0;

    private string name;
    public readonly int rollNumber;
    private string grade;

    public Student(string name, int rollNumber, string grade)
    {
        this.name = name;
        this.rollNumber = rollNumber;
        this.grade = grade;
        totalStudents++;
    }

    public void Display()
    {
        Console.WriteLine("University  : " + universityName);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Roll Number : " + rollNumber);
        Console.WriteLine("Grade       : " + grade);
        Console.WriteLine("----------------------------");
    }

    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students: " + totalStudents);
    }

    static void Main(string[] args)
    {
        // Hard-coded static value
        Student.universityName = "ABC University";

        // Hard-coded student objects
        object s1 = new Student("Vijay", 101, "A");
        object s2 = new Student("Anita", 102, "B+");

        // Type checking and casting
        if (s1 is Student)
        {
            ((Student)s1).Display();
        }

        if (s2 is Student)
        {
            ((Student)s2).Display();
        }

        // Display total students
        Student.DisplayTotalStudents();
    }
}
