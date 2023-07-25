using PosVentas.Infrastructure.Commons.Bases;

namespace PosVentas.Infrastructure.Helpers
{
    public static class QueryableHelper
    {
        //https://www.youtube.com/watch?v=8CMKKu2TVLg&list=PL-b0D_-Rciul_BHl6zR9B0K6fX2Hspfi8&index=4
        public static IQueryable<T>Paginate<T>(this IQueryable<T> queryable, BasePaginationRequest request)
        {
            return queryable.Skip((request.NumPage - 1) * request.Records).Take(request.Records);
        }
    }
}
