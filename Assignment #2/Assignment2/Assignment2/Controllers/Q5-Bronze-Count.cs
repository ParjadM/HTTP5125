using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q5_Bronze_Count : ControllerBase
    {
        [HttpGet("Bronze-Count")]
        public String result([FromQuery] int size, [FromQuery] List<int> numbers)
        {
            /// <summary>
            /// receive list of int and find the bronze and number of people receiving it
            /// </summary>
            /// <param name="numbers">receive the size</param>
            /// <param name="numbers">Receive a list of int</param>
            /// <returns>output a string, stating the bronze number and number of people receive it</returns>
            /// <example>
            /// 'GET' \
            /// 'https://localhost:7270/api/Q5_Bronze_Count/Bronze-Count?size=4&numbers=70&numbers=62&numbers=58&numbers=73&numbers=0' \
            /// 'accept: text/plain'
            /// -> The score required for bronze level 62 is and 1 participant achieved this score.
            /// </example>
           
            //sort in descending order
            numbers.Sort((a, b) => b.CompareTo(a));

            //intilize the highest number to first place
            int first = numbers[0];
            int second = 0;
            int third = 0;

            //find second place
            foreach (int number in numbers)
            {
                if (number != first)
                {
                    second = number;
                    break;
                }
            }
            //find third place
            foreach (int number in numbers)
            {
                if (number != first && number != second)
                {
                    third = number;
                    break;
                }
            }
            //count the number of times third place occured
            int count = 0;
            foreach (int number in numbers)
            {
                if (number == third)
                {
                    count++;
                }
            }
            //return the output
            return $"The score required for bronze level is {third} and {count} participants achieved this score.";
        }
    }
}

