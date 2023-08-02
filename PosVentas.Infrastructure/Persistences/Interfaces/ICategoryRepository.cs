using PosVentas.Domain.Entities;
using PosVentas.Infrastructure.Commons.Bases.Request;
using PosVentas.Infrastructure.Commons.Bases.Response;

namespace PosVentas.Infrastructure.Persistences.Interfaces
{
    public interface ICategoryRepository
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters);
        Task<IEnumerable<Category>> ListSelectCategories();
        Task<Category> CategoryById(int CategoryId);
        Task<bool> RegisterCategory(Category category);
        Task<bool> EditCategory(Category category);
        Task<bool> RemoveCategory(int CategoryId);


    }
}
