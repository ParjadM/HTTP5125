using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q3_Chili_Peppers : ControllerBase
    {
        [HttpGet(template: "Cupcake-Party")]
        public int result([FromQuery] String answer)
        {
            /// <summary>
            /// receive a string and tell user how hot it is
            /// </summary>
            /// <param name="answer">receive a string</param>
            /// <returns>output the sum of the string</returns>
            /// <example>
            /// GET :
            /// localhost: xx / api / J2 / ChiliPeppers & Ingredients = Poblano,
            /// Cayenne,Thai,Poblano'
            /// -> 118000
            /// </example>
            ///  <example>
            /// GET :
            /// localhost: xx / api / J2 / ChiliPeppers & Ingredients = Habanero
            /// ,Habanero,Habanero,Habanero,Habanero
            /// -> 625000
            /// </example>
            /// <example>
            /// GET :
            /// localhost: xx / api / J2 / ChiliPeppers & Ingredients = Poblano,
            /// Mirasol,Serrano,Cayenne,Thai,Habanero,Serrano
            /// -> 278500
            /// </example>
            // seprate using comma
            string[] pepperArray = answer.Split(',');
            int size = pepperArray.Length;
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                if (pepperArray[i] == "Poblano")
                {
                    sum += 1500;
                }
                else if (pepperArray[i] == "Mirasol")
                {
                    sum += 6000;
                }
                else if (pepperArray[i] == "Serrano")
                {
                    sum += 15500;
                }
                else if (pepperArray[i] == "Cayenne")
                {
                    sum += 40000;
                }
                else if (pepperArray[i] == "Thai")
                {
                    sum += 75000;
                }
                else if (pepperArray[i] == "Habanero")
                {
                    sum += 125000;
                }
                else
                {
                    sum += 0;
                }
            }
            return sum;
        }
    }
}
