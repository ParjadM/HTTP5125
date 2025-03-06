using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MySql.Data.MySqlClient;
using Cumulative1.Model;
using System.Security.Cryptography.X509Certificates;

namespace Cumulative1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : Controller
    {
        private readonly SchoolDbContext _context;
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Return teacher from database by using their ID
        /// </summary>
        /// <return>
        /// teacher object
        /// </return>
        [HttpGet]
        [Route(template: "ListTeachers")]
        public List<Teacher> ListTeachers()
        {
            List<Teacher> Teachers = new List<Teacher>();

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();

                Command.CommandText = "SELECT * FROM school";

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        int Id = Convert.ToInt32(ResultSet["Id"]);
                        string Name = ResultSet["Name"].ToString();
                        string Subject = ResultSet["Subject"].ToString();
                        DateTime HireDate = Convert.ToDateTime(ResultSet["HireDate"]);

                        Teacher CurrentTeacher = new Teacher()
                        {
                            Id = Id,
                            Name = Name,
                            Subject = Subject,
                            HireDate = HireDate
                        };
                        Teachers.Add(CurrentTeacher);
                    }
                }
            } 
            return Teachers;
        }
        [HttpGet]
        [Route(template: "FindTeacher/{id}")]
        public Teacher FindTeacher(int id)
        {
            Teacher SelectedTeacher = new Teacher();

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM school WHERE Id = @id";
                Command.Parameters.AddWithValue("@id", id);


                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        SelectedTeacher.Id = Convert.ToInt32(ResultSet["Id"]);
                        SelectedTeacher.Name = ResultSet["Name"].ToString();
                        SelectedTeacher.Subject = ResultSet["Subject"].ToString();
                        SelectedTeacher.HireDate = Convert.ToDateTime(ResultSet["HireDate"]);

                    }
                }
            }
            return SelectedTeacher;
        }
    }
}
