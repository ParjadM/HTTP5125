using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//default namespace
namespace Question1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q1Controller : ControllerBase
    {


        /// <summary>
        /// This method receives a get request and outputs a message
        /// </summary>
        /// <returns>
        /// This method returns a string "Welcome to 5125!"
        /// </returns>
        /// <example>
        /// GET api/Q1/Welcome -> Welcome to 5125!
        /// </example>
        [HttpGet(template: "Welcome")]
        public string Welcome()
        {
            return "Welcome to 5125!";
        }
    }
}
