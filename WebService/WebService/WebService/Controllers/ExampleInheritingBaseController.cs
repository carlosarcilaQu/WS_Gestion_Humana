using Business.Interfaces;
using DataAccess.Models;
using DTO.Request;
using DTO.Response;
using Microsoft.AspNetCore.Mvc;
using WebService.Controllers.Base;

namespace WebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExampleNonBaseController : BaseController<TablaRequest, TablaResponse, Tabla, long>
    {
        public ExampleNonBaseController(ITablaBLL datoBLL) : base(datoBLL)
        {
        }
    }
}
