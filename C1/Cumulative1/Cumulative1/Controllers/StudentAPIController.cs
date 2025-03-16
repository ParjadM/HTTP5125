using Cumulative1.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Cumulative1.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        
        public StudentAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of Students in the system.
        /// </summary>
        /// <example>
        /// GET api/Student/ListStudentNames -> 
        /// </example>
        /// <returns>
        /// A list of student names
        /// </returns>
        [HttpGet]
        [Route("ListStudentNames")]
        public List<string> ListStudentNames()
        {
            
            List<string> StudentNames = new List<string>();

            
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM Students";

                
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    
                    while (ResultSet.Read())
                    {
                        string StudentFName = ResultSet["Studentfname"].ToString();
                        string StudentLName = ResultSet["Studentlname"].ToString();
                        string StudentName = $"{StudentFName} {StudentLName}";

                        
                        StudentNames.Add(StudentName);
                    }
                }
            }

            
            return StudentNames;
        }
        /// <summary>
        /// Get a student by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStudentById/{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var Student = FindStudent(id);

            if (Student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            return Ok(Student);
        }

        /// <summary>
        /// Find a student by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>find student with that specific id mention in the input</returns>
        internal Student FindStudent(int id)
        {
            Student Student = null; 

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM Students WHERE Studentid = @id";
                Command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    if (ResultSet.Read())
                    {
                        
                        Student = new Student
                        {
                            Id = Convert.ToInt32(ResultSet["Studentid"]),
                            Name = $"{ResultSet["Studentfname"]} {ResultSet["Studentlname"]}",
                            Studentnumber = ResultSet["studentnumber"].ToString(),
                            Enroldate = Convert.ToDateTime(ResultSet["enroldate"])
                        };
                    }
                }
            }

            return Student; 
        }

        /// <summary>
        /// Returns a list of Students in the system.
        /// </summary>
        /// <returns>return list of all students in the system</returns>
        internal List<Student> ListStudents()
        {
            List<Student> Students = new List<Student>(); 

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM Students";

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                        
                        Students.Add(new Student
                        {
                            Id = Convert.ToInt32(ResultSet["Studentid"]),
                            Name = $"{ResultSet["Studentfname"]} {ResultSet["Studentlname"]}",
                            Studentnumber = ResultSet["studentnumber"].ToString(),
                            Enroldate = Convert.ToDateTime(ResultSet["enroldate"])
                        });
                    }
                }
            }

            return Students;
        }

    }
    }
