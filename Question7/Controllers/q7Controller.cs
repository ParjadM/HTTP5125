using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Question7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q7Controller : ControllerBase
    {
        [HttpGet(template: "timemachine")]
        public string TimeMachine(int days)
        {
            DateTime adjustedDate = DateTime.Today.AddDays(days);
            return adjustedDate.ToString("yyyy-MM-dd");

        }
    }
}
