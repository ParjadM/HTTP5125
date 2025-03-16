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

        // Dependency injection of database context
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of Teachers in the system.
        /// </summary>
        /// <example>
        /// GET api/Teacher/ListTeacherNames -> ["John Doe", "Jane Smith", ...]
        /// </example>
        /// <returns>
        /// A list of strings, formatted "{First Name} {Last Name}".
        /// </returns>
        [HttpGet]
        [Route("ListTeacherNames")]
        public List<string> ListTeacherNames()
        {
            // Create an empty list of Teacher Names
            List<string> TeacherNames = new List<string>();

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                // Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM teachers";

                // Gather Result Set of Query into a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    // Loop Through Each Row in the Result Set
                    while (ResultSet.Read())
                    {
                        string TeacherFName = ResultSet["teacherfname"].ToString();
                        string TeacherLName = ResultSet["teacherlname"].ToString();
                        string TeacherName = $"{TeacherFName} {TeacherLName}";

                        // Add the Teacher Name to the List
                        TeacherNames.Add(TeacherName);
                    }
                }
            }

            // Return the final list of teacher names
            return TeacherNames;
        }

        internal Teacher FindTeacher(int id)
        {
            Teacher teacher = null; // Initialize a null Teacher object.

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                // Prepare a query to find a teacher by ID.
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM teachers WHERE teacherid = @id";
                Command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    if (ResultSet.Read())
                    {
                        // Create a Teacher object from the result set.
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

            return teacher; // Return the Teacher object or null if not found.
        }


        internal List<Teacher> ListTeachers()
        {
            List<Teacher> Teachers = new List<Teacher>(); // Initialize an empty list.

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                // Prepare a query to retrieve all teachers.
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM teachers";

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        // Create a Teacher object for each row in the result set.
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

            return Teachers; // Return the list of teachers.
        }

    }
}
