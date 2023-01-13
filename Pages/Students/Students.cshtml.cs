using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CSharpWebApp.Pages
{
    public class StudentsModel : PageModel
    {
        public List<StudentInfo> listStudents = new List<StudentInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\MSSQLSERVER01;Initial Catalog=SchoolDatabase;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM students";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentInfo studentInfo = new StudentInfo();
                                studentInfo.id = "" + reader.GetInt32(0);
                                studentInfo.name = reader.GetString(1);
                                studentInfo.lname = reader.GetString(2);
                                studentInfo.email = reader.GetString(3);
                                studentInfo.phone = reader.GetString(4);
                                studentInfo.address = reader.GetString(5);
                                studentInfo.created_on = reader.GetDateTime(5).ToString();

                                listStudents.Add(studentInfo);
                            }
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
    public class StudentInfo 
    {
        public String id;
        public String name;
        public String lname;
        public String email;
        public String phone;
        public String address;
        public String created_on;
    }
}
