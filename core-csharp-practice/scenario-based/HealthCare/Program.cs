using System;
// dotnet add package Microsoft.Data.SqlClient
// dotnet add package System.Data.SqlClient   
class Program
{
    public static string connectionString =
        "Server=.\\SQLEXPRESS;Database=HealthClinicDB;Trusted_Connection=True;TrustServerCertificate=True;";

    static void Main()
    {
        Services services = new Services();

        while (true)
        {
            Console.WriteLine("\n1. Add Patient");
            Console.WriteLine("2. Add Doctor");
            Console.WriteLine("3. Book Appointment");
            Console.WriteLine("4. View Appointments");
            Console.WriteLine("5. Exit");


            int choice = int.Parse(Console.ReadLine());

            if (choice == 1) services.AddPatient();
            else if (choice == 2) services.AddDoctor();
            else if (choice == 3) services.BookAppointment();
            else if (choice == 4) services.ViewAppointments();
            else break;

        }
    }
}
