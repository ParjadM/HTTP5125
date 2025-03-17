using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Cumulative1.Models;
using System;
using System.Collections.Generic;
using Cumulative1.Model;

namespace Cumulative1.Controllers
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
        /// Returns a list of teacher names in the system.
        /// </summary>
        /// <example>
        /// GET api/Teacher/ListTeacherNames -> ["Alexander Bennett", "Caitlin Cummings"]
        /// </example>
        /// <returns>
        /// A list of teacher names.
        /// </returns>
        [HttpGet]
        [Route("ListTeacherNames")]
        public List<string> ListTeacherNames()
        {
            // Create an empty list of teacher names
            List<string> TeacherNames = new List<string>();

            using (MySqlConnection connection = _context.AccessDatabase())
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT CONCAT(teacherfname, ' ', teacherlname) AS FullName FROM teachers";

                using (MySqlDataReader resultSet = command.ExecuteReader())
                {
                    while (resultSet.Read())
                    {
                        string teacherName =resultSet["FullName"].ToString();
                        TeacherNames.Add(teacherName);
                    }
                }
            }

            // Return the final list of teacher names
            return TeacherNames;
        }

        /// <summary>
        /// Returns detailed information about a specific teacher by ID.
        /// </summary>
        /// <example>
        /// GET api/Teacher/FindTeacher/1 -> { "Id": 1, "Name": "Alexander Bennett", ... }
        /// </example>
        /// <param name="id">The ID of the teacher to retrieve.</param>
        /// <returns>
        /// A teacher object containing detailed information.
        /// </returns>
        [HttpGet]
        [Route("FindTeacher/{id}")]
        public Teacher FindTeacher(int id)
        {
            // Initialize an empty Teacher object
            Teacher selectedTeacher = null;

            using (MySqlConnection connection = _context.AccessDatabase())
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText= "SELECT * FROM teachers WHERE teacherid = @id";
                command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader resultSet = command.ExecuteReader())
                {
                    if (resultSet.Read())
                    {
                        selectedTeacher = new Teacher
                        {
                            Id = Convert.ToInt32(resultSet["teacherid"]),
                            Name = $"{resultSet["teacherfname"]} {resultSet["teacherlname"]}",
                            EmployeeNumber = resultSet["employeenumber"].ToString(),
                            HireDate = Convert.ToDateTime(resultSet["hiredate"])
                        };
                    }
                }
            }

            // Return the selected teacher or null if not found
            return selectedTeacher;
        }

        /// <summary>
        /// Returns a list of all teachers in the system.
        /// </summary>
        /// <example>
        /// GET api/Teacher/ListTeachers -> [{ "Id": 1, "Name": "Alexander Bennett", ... }, ...]
        /// </example>
        /// <returns>
        /// A list of all teacher objects.
        /// </returns>
        [HttpGet]
        [Route("ListTeachers")]
        public List<Teacher> ListTeachers()
        {
            // Create an empty list of teachers
            List<Teacher> teachers = new List<Teacher>();

            using (MySqlConnection connection = _context.AccessDatabase())
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM teachers";

                using (MySqlDataReader resultSet = command.ExecuteReader())
                {
                    // Loop through each row in the result set and populate the list
                    while (resultSet.Read())
                    {
                        teachers.Add(new Teacher
                        {
                            Id = Convert.ToInt32(resultSet["teacherid"]),
                            Name = $"{resultSet["teacherfname"]} {resultSet["teacherlname"]}",
                            EmployeeNumber = resultSet["employeenumber"].ToString(),
                            HireDate = Convert.ToDateTime(resultSet["hiredate"])
                        });
                    }
                }
            }

            // Return the final list of teachers
            return teachers;
        }
    }
}
