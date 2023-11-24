using AutoMapper;
using BlazorServer.DataAccess.Models.BaseEntity;
using Business.Automapper;
using Business.Interfaces.BaseBLL;
using Common.logs;
using DataAccess.Context;
using DTO.Response;
using DTO.Response.Constans;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.BLL.BaseBLL
{
    public class BaseBLL<TModeloRequest, TModeloResponse, TEntity, PK> : IBaseBLL<TModeloRequest, TModeloResponse, TEntity, PK>
     where TModeloRequest : new()
     where TModeloResponse : new()
     where TEntity : BaseEntity<PK>, new()
    {
        private readonly WebserviceContext _db;
        private readonly IMapper _mapper;
        public BaseBLL(IMapper mapper, IAppLogger<TModeloRequest> loggerOS)
        {
            _mapper = mapper;
            _db = new WebserviceContext();
        }

        public virtual async Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAll()
        {
            try
            {
                List<TEntity> listaRegistrosEntidad = await _db.Set<TEntity>().ToListAsync();

                List<TModeloResponse> listaRegistros = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModelList(listaRegistrosEntidad);

                if (listaRegistros.Count() > 0)
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseOK(listaRegistros);
                }
                else
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<TModeloResponse>>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>> getbyid(PK id)
        {
            try
            {
                TEntity? entidad = await _db.Set<TEntity>()
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));

                TModeloResponse registro = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModel(entidad);

                if (registro != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(registro);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {

                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>> Modify(TModeloRequest modeloModificado)
        {
            try
            {
                TEntity entidadModificada = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToEntity(modeloModificado);
                TEntity? entidad = await _db.Set<TEntity>()
                    .FirstOrDefaultAsync(x => x.Id.Equals(entidadModificada.Id));

                if (entidad == null)
                {
                    return null;
                }

                UpdateModel(modeloModificado, entidad);
                await _db.SaveChangesAsync();

                TModeloResponse modelo = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModel(entidad);

                if (modelo != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(modelo);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var query = await _db.Set<TEntity>().AsNoTracking().Where(expression).FirstOrDefaultAsync();
                TModeloResponse coneverted = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModel(query);

                if (coneverted != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(coneverted);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAsyncList(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var query = await _db.Set<TEntity>().AsNoTracking().Where(expression).ToListAsync();

                IEnumerable<TModeloResponse> modeloResponse = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModelList(query);

                if (modeloResponse.Count() > 0)
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseOK(modeloResponse);
                }
                else
                {
                    return GenericResponse<IEnumerable<TModeloResponse>>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<IEnumerable<TModeloResponse>>.ResponseError(ex.Message);
            }
        }

        public virtual async Task<GenericResponse<TModeloResponse>> Insert(TModeloRequest modelo)
        {
            try
            {
                TEntity entidad = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToEntity(modelo);
                _db.Set<TEntity>().Add(entidad);
                await _db.SaveChangesAsync();
                TModeloResponse modeloResponse = ConvertMapping<TModeloRequest, TModeloResponse, TEntity, PK>.ConvertToResponseModel(entidad);

                if (modelo != null)
                {
                    return GenericResponse<TModeloResponse>.ResponseOK(modeloResponse);
                }
                else
                {
                    return GenericResponse<TModeloResponse>.ResponseValidation(ConstansApp.Messages.NoData);
                }
            }
            catch (Exception ex)
            {
                return GenericResponse<TModeloResponse>.ResponseError(ex.Message);
            }
        }

        protected virtual void UpdateModel(TModeloRequest modelo, TEntity entidad)
        {
        }
    }
}
