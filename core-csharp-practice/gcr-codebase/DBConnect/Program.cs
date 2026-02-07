// using System;
// using System.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//             "Server=.\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;";

//         SqlConnection con = new SqlConnection(connectionString);

//         try
//         {
//             con.Open();
//             Console.WriteLine("Connection successful");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("Error: " + ex.Message);
//         }
//         finally
//         {
//             con.Close();
//         }
//     }
// }



using System;
using System.Data.SqlClient;

class Program
{
    static string Connection = "Server=.\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True";
    static void Main()
    {
        SqlConnection connection = new SqlConnection(Connection);
        connection.Open();

        string query = "Create table";
    }
}