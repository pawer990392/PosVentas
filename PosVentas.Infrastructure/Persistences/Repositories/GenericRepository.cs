using PosVentas.Infrastructure.Commons.Bases.Request;
using PosVentas.Infrastructure.Helpers;
using PosVentas.Infrastructure.Persistences.Interfaces;
using System.Linq.Dynamic.Core;

namespace PosVentas.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        //https://www3.uji.es/~belfern/Docencia/Presentaciones/ProgramacionAvanzada/Tema1/genericos.html#45
        ///https://cursos.arquitecturajava.com/p/java-lambda
        protected IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request,IQueryable<TDTO> queryable,bool pagination=false) where TDTO : class
        {
            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} desceding") : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination) queryDto = queryDto.Paginate(request);
             
            return queryDto;
        }
    }
}
