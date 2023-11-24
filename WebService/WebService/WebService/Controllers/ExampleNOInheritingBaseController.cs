using Business.Interfaces;
using DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleNOInheritingBaseController : ControllerBase
    {
        private readonly ITablaBLL _tablaBLL;
        public ExampleNOInheritingBaseController(ITablaBLL tablaBLL)
        {
            _tablaBLL = tablaBLL;
        }
        [HttpPost("PostCampanas")]
        public async Task<IActionResult> PostCampanas([FromBody] TablaRequest requestCampana)
        {
            var Consumption = await _tablaBLL.GetAsyncList(x => x.Id == requestCampana.Id);
            if (Consumption.Codigo == 200)
            {
                return Ok(Consumption);
            }
            return BadRequest(Consumption);
        }
    }
}
