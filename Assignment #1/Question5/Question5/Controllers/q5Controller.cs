using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Question5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q5Controller : ControllerBase
    {
        [HttpPost(template: "secret")]
        public string Post1([FromBody] int Secret)
        {
            return "Shh.. the secret is " + Secret;
        }
    }
}
