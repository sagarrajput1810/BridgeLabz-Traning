using System;

interface IMedicalRecord
{
    void AddRecord(string record);
    string ViewRecords();
}

abstract class Patient
{
    private int patientId;
    private string name;

    protected Patient(int id, string name)
    {
        patientId = id;
        this.name = name;
    }

    public abstract double CalculateBill();

    public void GetPatientDetails()
    {
        Console.WriteLine("ID: " + patientId);
        Console.WriteLine("Name: " + name);
    }
}

class InPatient : Patient
{
    private int days;

    public InPatient(int id, string name, int days)
        : base(id, name)
    {
        this.days = days;
    }

    public override double CalculateBill()
    {
        return days * 2000;
    }
}

class HospitalPatientManagement
{
    static void Main()
    {
        Patient p = new InPatient(1, "Ramesh", 5);
        p.GetPatientDetails();
        Console.WriteLine("Bill: " + p.CalculateBill());
    }
}
