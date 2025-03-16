using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Cumulative1.Models;
using System.Collections.Generic;

namespace Cumulative1.Model
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of Teachers in the system.
        /// </summary>
        /// <example>
        /// GET api/Teacher/ListTeacherNames -> [(Alexander,Bennett),(Caitlin,Cummings)]
        /// </example>
        /// <returns>
        /// return a list of teacher names
        /// </returns>
        [HttpGet]
        [Route("ListTeacherNames")]
        public List<string> ListTeacherNames()
        {
            List<string> TeacherNames = new List<string>();

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM teachers";

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        string TeacherFName = ResultSet["teacherfname"].ToString();
                        string TeacherLName = ResultSet["teacherlname"].ToString();
                        string TeacherName = $"{TeacherFName} {TeacherLName}";

                        TeacherNames.Add(TeacherName);
                    }
                }
            }
            return TeacherNames;
        }
        /// <summary>
        /// Find a teacher by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list that specific teacher in database</returns>
        internal Teacher FindTeacher(int id)
        {
            // Create an empty teacher object
            Teacher teacher = null;
            // Create a connection to the database
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                // Open the connection between the web server and database
                Connection.Open();
                // Create a new SQL command
                MySqlCommand Command = Connection.CreateCommand();
                // SQL command to select a teacher by their ID
                Command.CommandText = "SELECT * FROM teachers WHERE teacherid = @id";
                // Bind the parameter to the SQL command
                Command.Parameters.AddWithValue("@id", id);
                // Execute the SQL command
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    if (ResultSet.Read())
                    {
                        
                        teacher = new Teacher
                        {
                            Id = Convert.ToInt32(ResultSet["teacherid"]),
                            Name = $"{ResultSet["teacherfname"]} {ResultSet["teacherlname"]}",
                            EmployeeNumber = ResultSet["employeenumber"].ToString(),
                            HireDate = Convert.ToDateTime(ResultSet["hiredate"])
                        };
                    }
                }
            }
            // Return the teacher object
            return teacher;
        }

        /// <summary>
        /// List all teachers in the database.
        /// </summary>
        /// <returns>list all the teachers name in the database</returns>
        internal List<Teacher> ListTeachers()
        {
            // Create an empty list of teachers
            List<Teacher> Teachers = new List<Teacher>();
            // Create a connection to the database
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                // Open the connection between the web server and database
                Connection.Open();
                // Create a new SQL command
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM teachers";
                // Execute the SQL command
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        Teachers.Add(new Teacher
                        {
                            Id = Convert.ToInt32(ResultSet["teacherid"]),
                            Name = $"{ResultSet["teacherfname"]} {ResultSet["teacherlname"]}",
                            EmployeeNumber = ResultSet["employeenumber"].ToString(),
                            HireDate = Convert.ToDateTime(ResultSet["hiredate"])
                        });
                    }
                }
            }
            // Return the list of teachers
            return Teachers; 
        }

    }
}
