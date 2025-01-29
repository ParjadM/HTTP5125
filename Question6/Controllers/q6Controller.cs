using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace Question6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q6Controller : ControllerBase
    {
        /// <summary>
        /// calculate the hexgon by getting the side
        /// </summary>
        /// <returns>return the hexond</returns>
        /// <param name="Side>Side to hexagon</param>\
        /// <example>
        /// GET api/Route/Welcome?CourseCode=5125&Section=B&Semester=Summer -> "Welcome to 5125 Section B Summer Semester"
        /// </example>
        /// <example>
        /// GET api/Route/Welcome?CourseCode=5126&Section=A&Semester=Winter -> "Welcome to 5126 Section A Winter Semester"
        /// </example>
        [HttpGet(template: "hexagon")]
        public double hexagon(double Side)
        {
            double result = ((3 * Math.Sqrt(3)) / 2) * Math.Pow(Side, 2);
            return result;
        }
    }
}
