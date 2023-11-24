using DTO.Response;
using System.Linq.Expressions;

namespace Business.Interfaces.BaseBLL
{
    public interface IBaseBLL<TModeloRequest, TModeloResponse, TEntity, PK>
    where TModeloRequest : new()
    where TModeloResponse : new()
    where TEntity : new()
    {
        Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAll();
        Task<GenericResponse<TModeloResponse>> getbyid(PK id);
        Task<GenericResponse<TModeloResponse>> Modify(TModeloRequest modeloModificado);
        Task<GenericResponse<TModeloResponse>> Insert(TModeloRequest modelo);
        Task<GenericResponse<TModeloResponse>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<GenericResponse<IEnumerable<TModeloResponse>>> GetAsyncList(Expression<Func<TEntity, bool>> expression);
    }
}
