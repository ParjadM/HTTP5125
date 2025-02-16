using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q2_Cupcake_Party : ControllerBase
    {
        /// <summary>
        /// received a two int and display how many cupcake are left
        /// </summary>
        /// <param name="R">each R equals 8</param>
        /// <param name="S">each S equals 3</param>
        /// <returns>output the remainder of cupcakes left</returns>
        /// <example>
        /// Post : 'https://localhost:7270/api/Q2_Cupcake_Party/Cupcake-Party' 
        /// 'Content-Type: application/x-www-form-urlencoded' \
        /// 'R=2&S=5'
        /// -> 3
        /// </example>
        ///  <example>
        /// Post : 'https://localhost:7270/api/Q2_Cupcake_Party/Cupcake-Party' 
        /// 'Content-Type: application/x-www-form-urlencoded' \
        /// 'R=2&S=4'
        /// -> 0
        /// </example>
        [HttpPost(template: "Cupcake-Party")]
        [Consumes("application/x-www-form-urlencoded")]

        public int result([FromForm] int R, [FromForm] int S)
        {
            int remainder = (R * 8) + (S * 3);
            return remainder - 28;
        }
    }
}
