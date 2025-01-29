using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Question8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class q8Controller : ControllerBase
    {
        [HttpPost(template: "squashfellows")]
        [Consumes("application/x-www-form-urlencoded")]
        public string SquashFellows([FromForm] int small, [FromForm] int large)
        {
            double stotal = small * 25.50;
            double ltotal = large * 40.50;
            double SubTotal = stotal + ltotal;
            double Tax = SubTotal * 0.13;
            double Total = SubTotal + Tax;
            string message= $"{small} Small @ $25.50 = ${Math.Round(stotal, 2)}; {large} Small @ $25.50 = ${Math.Round(ltotal, 2)}; Subtotal = ${Math.Round(SubTotal, 2)}; Tax = ${Math.Round(Tax, 2)}  HST; Total = ${Math.Round(Total, 2)}";
            return message;
        }
    }
}
