using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Question4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q4Controller : ControllerBase
    {

        [HttpPost(template: "knockknock")]
        public string knockknock()
        {
            return "Who’s there?";
        }
    }
}
