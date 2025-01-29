using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Question2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q2Controller : ControllerBase
    {
        /// <summary>
        /// Hi there! This is a simple API that returns a welcome greeting based on the course code entered.
        /// </summary>
        /// <returns>A welcome greeting based on the course code entered</returns>
        /// <param name="name">The name to greet</param>
        /// <example>
        /// GET api/Route/Welcome?CourseCode=5125&Section=B&Semester=Summer -> "Welcome to 5125 Section B Summer Semester"
        /// </example>
        /// <example>
        /// GET api/Route/Welcome?CourseCode=5126&Section=A&Semester=Winter -> "Welcome to 5126 Section A Winter Semester"
        /// </example>

        [HttpGet(template: "greeting")]
        public string greeting(string name)
        {
            //save it to message and return message
            string message = $"Hi {name}!";
            return message;
        }
    }
}
