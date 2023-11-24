using Business.Interfaces.Login;
using DTO.Request.Login;
using DTO.Response;
using DTO.Response.Login;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginBLL _bll;

        public LoginController(ILoginBLL bll)
        {
            _bll = bll;
        } 

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _bll.Login(loginRequest);
            if (result.Codigo == 200)
            {
                GenericResponse<LoginResponse> respuestaGenerica = result;
                return Ok(respuestaGenerica);
            }
            return BadRequest(result);
        }
    }
}
