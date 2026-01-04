using System;

class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Teacher : Person
{
    public string Subject;

    public Teacher(string name, int age, string subject)
        : base(name, age)
    {
        Subject = subject;
    }

    public void DisplayRole()
    {
        Console.WriteLine("Role: Teacher");
    }
}

class Student : Person
{
    public string Grade;

    public Student(string name, int age, string grade)
        : base(name, age)
    {
        Grade = grade;
    }

    public void DisplayRole()
    {
        Console.WriteLine("Role: Student");
    }
}

class Staff : Person
{
    public string Department;

    public Staff(string name, int age, string department)
        : base(name, age)
    {
        Department = department;
    }

    public void DisplayRole()
    {
        Console.WriteLine("Role: Staff");
    }
}

class PersonTest
{
    static void Main()
    {
        Teacher t = new Teacher("Ravi", 35, "Maths");
        Student s = new Student("Anita", 20, "A");
        Staff st = new Staff("Suresh", 40, "Admin");

        t.DisplayRole();
        s.DisplayRole();
        st.DisplayRole();
    }
}
