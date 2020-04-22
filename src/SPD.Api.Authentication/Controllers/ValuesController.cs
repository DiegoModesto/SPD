using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SPD.Api.Authentication.Controllers
{
    [ApiController]
    [Route("api/values")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Obrigado");
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Test via get its worked");
        }
    }
}
