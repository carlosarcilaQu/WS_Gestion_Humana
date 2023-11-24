using AutoMapper;
using BlazorServer.DataAccess.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Automapper
{
    public static class ConvertMapping<TModelRequest, TModelResponse, TEntity, PK>
    where TModelRequest : new()
    where TModelResponse : new()
    where TEntity : BaseEntity<PK>, new()
    {
        private static readonly IMapper _mapper;
        private static IMapper? mapper;

        static ConvertMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TEntity>();
                cfg.CreateMap<TEntity, TModelResponse>().ReverseMap();
                cfg.CreateMap<TModelRequest, TEntity>().ReverseMap();
                cfg.CreateMap<TModelRequest, TModelResponse>().ReverseMap();
                cfg.CreateMap<TModelResponse, TModelResponse>();
            });
            _mapper = config.CreateMapper();
        }

        public static TEntity ConvertToEntity(TModelRequest model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            return entity;
        }

        public static TModelResponse ConvertToResponseModel(TEntity entity)
        {
            TModelResponse model = _mapper.Map<TModelResponse>(entity);
            return model;
        }

        public static List<TModelResponse> ConvertToResponseModelList(List<TEntity> entityList)
        {
            List<TModelResponse> responseValueList = _mapper.Map<List<TModelResponse>>(entityList);
            return responseValueList;
        }

        public static TEntity ConvertEntityToEntity(TEntity entity)
        {
            TEntity model = _mapper.Map<TEntity>(entity);
            return model;
        }

        public static List<TModelResponse> ConvertirEnListaModeloResponseEnModeloResponse(List<TModelResponse> modelList)
        {
            List<TModelResponse> responseValueList = _mapper.Map<List<TModelResponse>>(modelList);
            return responseValueList;
        }

        public static TModelRequest ConvertirEnModeloRequest(TModelResponse model)
        {
            TModelRequest modelRequest = _mapper.Map<TModelRequest>(model);
            return modelRequest;
        }
    }
}
