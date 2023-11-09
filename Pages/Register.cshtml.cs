using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Your_Music_Depot_Application_DBAS6201.Pages
{
    public class RegisterModel : PageModel
    {
        public newStudent newstudent = new newStudent();
        public void OnGet()
        {

        }

        public void OnPost()
        {
            Random rand = new Random();
            String lengthpassword = Request.Form["password"];

            //generate a random ID
            
            if (Request.Form["firstname"] == "" || int.TryParse(Request.Form["firstname"], out int invalidfirstname) ||
                Request.Form["lastname"] == "" || int.TryParse(Request.Form["lastname"], out int invalidlastname) ||
                Request.Form["age"] == "" || !int.TryParse(Request.Form["age"], out int invalidage) ||
                Request.Form["instrument"] == "" || int.TryParse(Request.Form["instrument"], out int invalidinstrument) ||
                Request.Form["skilllevel"] == "" || int.TryParse(Request.Form["skilllevel"], out int invalidskill) ||
                Request.Form["phonenumber"] == "" || !int.TryParse(Request.Form["phonenumber"], out int invalidnumber) ||
                Request.Form["email"] == "" || Request.Form["email"].Contains("@") ||
                Request.Form["password"] == "" || lengthpassword.Length <= 8)
            {
                if (Request.Form["firstname"] == "")
                {

                }
                else if (int.TryParse(Request.Form["firstname"], out invalidfirstname))
                {

                }
            
                if (Request.Form["lastname"] == "")
                {

                }
                else if (int.TryParse(Request.Form["lastname"], out invalidlastname))
                {

                }

                if (Request.Form["age"] == "")
                {

                }
                else if (!int.TryParse(Request.Form["age"], out int invalidage2))
                {

                }

                if (Request.Form["instrument"] == "")
                {

                }
                else if (int.TryParse(Request.Form["instrument"], out invalidinstrument))
                {

                }

                if (Request.Form["skilllevel"] == "")
                {

                }
                else if(int.TryParse(Request.Form["skilllevel"], out invalidskill))

                if (Request.Form["phonenumber"] == "")
                {

                }
                else if (!int.TryParse(Request.Form["phonenumber"], out invalidnumber))
                {

                }

                if (Request.Form["email"] == "")
                {

                }
                else if (Request.Form["email"].Contains("@"))
                {

                }

                if (Request.Form["password"] == "")
                {

                }
                else if (lengthpassword.Length <= 8)
                {

                }
                Console.WriteLine("Registration failed");
            }
            else
            {
                int randomID = rand.Next(100000, 100000000);

                //if validation is successful, go here
                if (int.TryParse(Request.Form["phonenumber"], out int phonenumber))
                {
                    phonenumber = int.Parse(Request.Form["phonenumber"]);
                }
                newstudent.StudentEmail = Request.Form["email"];
                newstudent.StudentPassword = Request.Form["password"];

                if (int.TryParse(Request.Form["age"], out int age) )
                {
                    age = int.Parse(Request.Form["age"]);
                }

                try
                {
                    Console.WriteLine(Request.Form["firstname"]);
                    Console.WriteLine(Request.Form["lastname"]);
                    Console.WriteLine(Request.Form["age"]);
                    Console.WriteLine(Request.Form["instrument"]);
                    Console.WriteLine(Request.Form["skilllevel"]);
                    Console.WriteLine(Request.Form["phonenumber"]);
                    Console.WriteLine(Request.Form["email"]);
                    Console.WriteLine(Request.Form["password"]);
                    /**/
                    String connectionString = "Data Source=LAPTOP-E8H3L8KS;Initial Catalog=YourMusicDepot;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        String insertNew = "INSERT INTO [Students/Étudiants] VALUES(" + randomID + ", '" + Request.Form["firstname"] + "', '" + Request.Form["lastname"] + "', " + age + ", '" + Request.Form["instrument"] + "', '" + Request.Form["skilllevel"] + "', " + phonenumber + ", '" + Request.Form["email"] + "', HASHBYTES('SHA1', '" + Request.Form["password"] + "'));";
                        Console.WriteLine(insertNew);
                        connection.Close();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.ToString());
                }
            }
        }

        public class newStudent
        {
            public int StudentID;
            public string StudentFirstName;
            public string StudentLastName;
            public int StudentAge;
            public string StudentInstrumentPreference;
            public string StudentSkillLevel;
            public int StudentPhoneNumber;
            public string StudentEmail;
            public string StudentPassword;
             
        }
    }
}
