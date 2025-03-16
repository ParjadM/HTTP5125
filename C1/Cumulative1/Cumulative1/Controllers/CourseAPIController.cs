using Cumulative1.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Cumulative1.Controllers
{
    public class CourseAPIController : ControllerBase
    {
        // Dependency injection of database context
        private readonly SchoolDbContext _context;
        public CourseAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of Courses in the system.
        /// </summary>
        /// <example>
        /// GET api/Course/ListCourseNames -> ["http5101", "http5102", "http5103"]
        /// </example>
        /// <returns>
        /// A list of course names
        /// </returns>
        [HttpGet]
        [Route("ListCourseNames")]
        public List<string> ListCourseNames()
        {
            // Create an empty list of Course Names
            List<string> CourseNames = new List<string>();

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM Courses";

                
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    
                    while (ResultSet.Read())
                    {
                        string CourseFName = ResultSet["coursename"].ToString();
                        string CourseName = $"{CourseFName}";

                        // Add the Course Name to the List
                        CourseNames.Add(CourseName);
                    }
                }
            }

            
            return CourseNames;
        }
        /// <summary>
        /// Get a course by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return course information by ID</returns>
        [HttpGet]
        [Route("GetCourseById/{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var Course = FindCourse(id);

            if (Course == null)
            {
                return NotFound(new { message = "Course not found" });
            }

            return Ok(Course);
        }
        internal Course FindCourse(int id)
        {
            Course Course = null; 

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM Courses WHERE Courseid = @id";
                Command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    if (ResultSet.Read())
                    {
                        
                        Course = new Course
                        {
                            Id = Convert.ToInt32(ResultSet["Courseid"]),
                            Name = $"{ResultSet["coursename"]}",
                            Teacherid = Convert.ToInt32(ResultSet["teacherid"]),
                            Startdate = Convert.ToDateTime(ResultSet["startdate"]),
                            Finishdate = Convert.ToDateTime(ResultSet["finishdate"]),
                            Coursecode = ResultSet["coursecode"].ToString()
                        };
                    }
                }
            }

            return Course; 
        }


        internal List<Course> ListCourses()
        {
            List<Course> Courses = new List<Course>(); 

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM Courses";

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                       
                        Courses.Add(new Course
                        {
                            Id = Convert.ToInt32(ResultSet["Courseid"]),
                            Name = $"{ResultSet["coursename"]}",
                            Teacherid = Convert.ToInt32(ResultSet["teacherid"]),
                            Startdate = Convert.ToDateTime(ResultSet["startdate"]),
                            Finishdate = Convert.ToDateTime(ResultSet["finishdate"]),
                            Coursecode = ResultSet["coursecode"].ToString()
                        });
                    }
                }
            }

            return Courses; 
        }
    }
}
