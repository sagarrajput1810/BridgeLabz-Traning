using System;
using System.Data.SqlClient;

class Services
{
    public void AddPatient()
    {
        SqlConnection con = new SqlConnection(Program.connectionString);
        con.Open();

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Address: ");
        string address = Console.ReadLine();

        Console.Write("Enter Blood Group: ");
        string blood = Console.ReadLine();

        string query =
            "INSERT INTO Patients (Name, Phone, Email, Address, BloodGroup) " +
            "VALUES (@Name,@Phone,@Email,@Address,@Blood)";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Phone", phone);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Address", address);
        cmd.Parameters.AddWithValue("@Blood", blood);

        cmd.ExecuteNonQuery();
        con.Close();

        Console.WriteLine("Patient Added Successfully");
    }
    public void BookAppointment()
    {
        SqlConnection con = new SqlConnection(Program.connectionString);
        con.Open();

        Console.Write("Enter Patient ID: ");
        int patientId = int.Parse(Console.ReadLine());

        Console.Write("Enter Doctor ID: ");
        int doctorId = int.Parse(Console.ReadLine());

        Console.Write("Enter Date (yyyy-mm-dd): ");
        string date = Console.ReadLine();

        Console.Write("Enter Time (hh:mm): ");
        string time = Console.ReadLine();

        string query =
            "INSERT INTO Appointments " +
            "(PatientId, DoctorId, AppointmentDate, AppointmentTime, Status) " +
            "VALUES (@Pid,@Did,@Date,@Time,'SCHEDULED')";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Pid", patientId);
        cmd.Parameters.AddWithValue("@Did", doctorId);
        cmd.Parameters.AddWithValue("@Date", date);
        cmd.Parameters.AddWithValue("@Time", time);

        cmd.ExecuteNonQuery();
        con.Close();

        Console.WriteLine("Appointment Booked Successfully");
    }

    public void AddDoctor()
    {
        SqlConnection con = new SqlConnection(Program.connectionString);
        con.Open();

        Console.Write("Doctor Name: ");
        string name = Console.ReadLine();

        Console.Write("Specialty: ");
        string specialty = Console.ReadLine();

        Console.Write("Fee: ");
        int fee = int.Parse(Console.ReadLine());

        string query =
            "INSERT INTO Doctors (Name, Specialty, Fee, IsActive) " +
            "VALUES (@Name,@Specialty,@Fee,1)";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Specialty", specialty);
        cmd.Parameters.AddWithValue("@Fee", fee);

        cmd.ExecuteNonQuery();
        con.Close();

        Console.WriteLine("Doctor Added");
    }

    public void ViewAppointments()
    {
        SqlConnection con = new SqlConnection(Program.connectionString);
        con.Open();

        string query =
            "SELECT A.AppointmentId, " +
            "P.Name AS PatientName, P.Phone, " +
            "D.Name AS DoctorName, D.Specialty, " +
            "A.AppointmentDate, A.AppointmentTime, A.Status " +
            "FROM Appointments A " +
            "JOIN Patients P ON A.PatientId = P.PatientId " +
            "JOIN Doctors D ON A.DoctorId = D.DoctorId";

        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataReader dr = cmd.ExecuteReader();

        Console.WriteLine("\n--- Appointment Details ---");

        while (dr.Read())
        {
            Console.WriteLine(
                "Appointment ID: " + dr["AppointmentId"] +
                " | Patient: " + dr["PatientName"] +
                " | Phone: " + dr["Phone"] +
                " | Doctor: " + dr["DoctorName"] +
                " | Specialty: " + dr["Specialty"] +
                " | Date: " + dr["AppointmentDate"] +
                " | Time: " + dr["AppointmentTime"] +
                " | Status: " + dr["Status"]
            );
        }

        con.Close();
    }
}
