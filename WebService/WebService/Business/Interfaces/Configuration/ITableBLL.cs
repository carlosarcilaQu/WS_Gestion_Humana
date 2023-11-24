using Business.Interfaces.BaseBLL;
using DataAccess.Models;
using DTO.Request.Configuration;
using DTO.Response.Configuration;

namespace Business.Interfaces.Configuration
{
    public interface ITableBLL : IBaseBLL<TableRequest, TableResponse, Table, long>
    {
    }
}
