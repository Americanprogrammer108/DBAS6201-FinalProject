using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Your_Music_Depot_Application_DBAS6201.Pages.Login.Student
{
    public class InstructorsModel : PageModel
    {
        public List<Instructor> Instructors = new List<Instructor>();
        public void OnGet()
        {
            try
            {
                String connectionstring = "Data Source=LAPTOP-E8H3L8KS;Initial Catalog=YourMusicDepot;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Instructors/Instructeurs;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Instructor instructorInfo = new Instructor();
                                instructorInfo.ID = reader.GetInt32(0);
                                instructorInfo.FName = reader.GetString(1);
                                instructorInfo.LName = reader.GetString(2);
                                instructorInfo.Credentials = reader.GetString(3);
                                instructorInfo.Availability = reader.GetString(4);
                                instructorInfo.PhoneNumber = reader.GetInt32(5);
                                instructorInfo.Email = reader.GetString(6);

                                Instructors.Add(instructorInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }
    }

    public class Instructor
    {
        public int ID;
        public String FName;
        public String LName;
        public String Credentials;
        public String Availability;
        public int PhoneNumber;
        public String Email;
    }
}
