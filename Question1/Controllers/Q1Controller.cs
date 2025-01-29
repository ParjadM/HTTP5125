using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Question1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q1Controller : ControllerBase
    {
        [HttpGet(template: "Welcome")]
        public string Welcome()
        {
            return "Welcome to 5125!";
        }
    }
}
