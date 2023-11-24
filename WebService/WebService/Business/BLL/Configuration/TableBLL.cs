using AutoMapper;
using Business.BLL.BaseBLL;
using Business.Interfaces.Configuration;
using Common.logs;
using DataAccess.Models;
using DTO.Request;
using DTO.Request.Configuration;
using DTO.Response.Configuration;

namespace Business.BLL.Configuration
{
    public class TableBLL : BaseBLL<TableRequest, TableResponse, Table, long>, ITableBLL
    {
        private readonly IMapper _mapper;
        public TableBLL(IMapper mapper, IAppLogger<TableRequest> loggerOS) : base(mapper, loggerOS)
        {
            _mapper = mapper;
        }
    }
}
