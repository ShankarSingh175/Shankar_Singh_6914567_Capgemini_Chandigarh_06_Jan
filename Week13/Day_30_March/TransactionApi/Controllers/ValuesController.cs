using Microsoft.AspNetCore.Mvc;

namespace TransactionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "Value1", "Value2" });
        }
    }
}