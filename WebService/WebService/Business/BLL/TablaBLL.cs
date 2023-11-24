using AutoMapper;
using Business.BLL.BaseBLL;
using Business.Interfaces;
using Common.logs;
using DataAccess.Models;
using DTO.Request;
using DTO.Response;

namespace Business.BLL
{
    public class TablaBLL : BaseBLL<TablaRequest, TablaResponse, Tabla, long>, ITablaBLL
    {
        private readonly IMapper _mapper;
        public TablaBLL(IMapper mapper, IAppLogger<TablaRequest> loggerOS) : base(mapper, loggerOS)
        {
            _mapper = mapper;
        }

        protected override void UpdateModel(TablaRequest modelo, Tabla entidad)
        {
            entidad.Id = modelo.Id;
        }
    }
}
