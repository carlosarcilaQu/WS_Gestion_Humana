using Business.Interfaces.Configuration;
using DataAccess.Models;
using DTO.Request.Configuration;
using DTO.Response.Configuration;
using Microsoft.AspNetCore.Mvc;
using WebService.Controllers.Base;

namespace WebService.Controllers.Configuration
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TableController : BaseController<TableRequest, TableResponse, Table, long>
    {
        public TableController(ITableBLL datoBLL) : base(datoBLL)
        {
        }
    }
}
