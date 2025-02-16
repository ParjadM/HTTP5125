using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q4_Dusa_And_The_Yobis : ControllerBase
    {
        [HttpGet(template: "Dusa-And-The-Yobis")]
        public int result([FromQuery] List<int> numbers)
        {
            /// <summary>
            /// receive list of int and returns if dusa can eat yobis or not and then output the result
            /// </summary>
            /// <param name="numbers">Receive a list of int</param>
            /// <returns>output the sum of the list that Dusa can eat</returns>
            /// <example>
            /// 'GET' 
            /// 'https://localhost:7270/api/Q4_Dusa_And_The_Yobis/Dusa-And-The_Yobis?numbers=5&numbers=3&numbers=2&numbers=9&numbers=20&numbers=22&numbers=14' \
            /// 'accept: text/plain'
            /// -> 19
            /// </example>
            int sum = numbers[0];
            for (int i = 1; i < numbers.Count;i++)
            {
                if (sum > numbers[i])
                {
                    sum += numbers[i];
                }
                else
                {
                    return sum;
                }
            }
            return sum;
        
        }

    }
}

