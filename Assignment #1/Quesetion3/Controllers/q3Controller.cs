using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Quesetion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q3Controller : ControllerBase
    {
        /// <summary>
        /// Receives a num and outputs the cube of the num
        /// </summary>
        /// <param name="num">The num user enter</param>
        /// <returns>returning the cube</returns>
        /// <example>
        /// GET http://localhost:xx/api/q3/cube/4 -> 64
        /// </example>
        /// <example>
        /// GET http://localhost:xx/api/q3/cube/-4 -> -64
        /// </example>
        /// <example>
        /// GET http://localhost:xx/api/q3/cube/10 -> 1000
        /// </example>
        [HttpGet(template: "/api/q3/cube/{num}")]
        public int Cube(int num)
        {
            //finding the cube of the number
            int result = num * num * num;
            //returning the cube as output
            return result;

        }
    }
}
