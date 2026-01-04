using System;

class Patient
{
    public static string hospitalName;
    private static int totalPatients = 0;

    private string name;
    private int age;
    private string ailment;
    public readonly int patientId;

    public Patient(string name, int age, string ailment, int patientId)
    {
        this.name = name;
        this.age = age;
        this.ailment = ailment;
        this.patientId = patientId;
        totalPatients++;
    }

    public void Display()
    {
        Console.WriteLine("Hospital    : " + hospitalName);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Age         : " + age);
        Console.WriteLine("Ailment     : " + ailment);
        Console.WriteLine("Patient ID  : " + patientId);
        Console.WriteLine("---------------------------");
    }

    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients: " + totalPatients);
    }

    static void Main(string[] args)
    {
        // Hard-coded static value
        Patient.hospitalName = "City Care Hospital";

        // Hard-coded patient objects
        object p1 = new Patient("Ramesh Kumar", 35, "Fever", 1001);
        object p2 = new Patient("Sita Sharma", 28, "Migraine", 1002);

        // Type checking and casting
        if (p1 is Patient)
        {
            ((Patient)p1).Display();
        }

        if (p2 is Patient)
        {
            ((Patient)p2).Display();
        }

        // Display total patients
        Patient.GetTotalPatients();
    }
}
