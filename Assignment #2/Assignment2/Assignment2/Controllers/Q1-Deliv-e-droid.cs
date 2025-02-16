using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q1_Deliv_e_droid : ControllerBase
    {
        /// <summary>
        /// received a two int and dispaly the deli-e-droid
        /// </summary>
        /// <param name="Deliveries">add 50</param>
        /// <param name="Collisions">subtract 10</param>
        /// <returns>output int value with sum total</returns>
        /// <example>
        /// POST : localhost:xx/api/J1/Delivedroid
        /// Content-Type: application/x-www-form-urlencoded
        /// Request Body:
        /// Collisions=2&Deliveries=5
        /// -> 730
        /// </example>
        /// /// <example>
        /// POST : localhost:xx/api/J1/Delivedroid
        /// Content-Type: application/x-www-form-urlencoded
        /// Request Body:
        /// Collisions=10&Deliveries=0
        /// -> -100
        /// </example>
        /// <example>
        /// POST : localhost:xx/api/J1/Delivedroid
        /// Content-Type: application/x-www-form-urlencoded
        /// Request Body:
        /// Collisions=3&Deliveries=2
        /// -> 70 
        /// </example>

        [HttpPost(template: "Deli-e-droid")]
        [Consumes("application/x-www-form-urlencoded")]
        public int result([FromForm] int Deliveries, [FromForm] int Collisions)
        {
            int sum = (Deliveries * 50) - (Collisions * 10);
            if (Deliveries > Collisions)
            {
                sum += 500;
            }

            return sum;
        }
    }
}
