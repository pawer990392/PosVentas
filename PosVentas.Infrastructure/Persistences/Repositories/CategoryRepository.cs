using Microsoft.EntityFrameworkCore;
using PosVentas.Domain.Entities;
using PosVentas.Infrastructure.Commons.Bases.Request;
using PosVentas.Infrastructure.Commons.Bases.Response;
using PosVentas.Infrastructure.Persistences.Contexts;
using PosVentas.Infrastructure.Persistences.Interfaces;
using PosVentas.Utilities.Static;


namespace PosVentas.Infrastructure.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        private readonly PosContext _context;

        public CategoryRepository(PosContext context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters)
        {
            
            var response = new BaseEntityResponse<Category>();
            var categories=(from c in _context.Categories
                            where c.AuditDeleteUser==null && c.AuditDeleteDate==null
                            select c).AsNoTracking().AsQueryable();

            if(filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch(filters.NumFilter)
                {
                    case 1:                                                  //bebeidas
                        categories = categories.Where(x => x.Name!.Contains(filters.TextFilter));
                        break;
                case 2:
                        categories = categories.Where(x => x.Description!.Contains(filters.TextFilter));
                        break;

                }
            }
            
            //caso de estados cuando nos ea nulo
            if(filters.StateFilter is not null)
            {
                categories = categories.Where(x => x.State.Equals(filters.StateFilter));

            }
            //filtro para las fechas
            if(!string.IsNullOrEmpty(filters.StarDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                categories=categories.Where(x=>x.AuditCreateDate >= Convert.ToDateTime(filters.StarDate) && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }
            //alplicAR EL FILTRO EN ESTE CASO para ordenenar 
            if(filters.Sort is null)
            {
                filters.Sort = "CategoryId";
            }
            response.TotalRecords=await categories.CountAsync();
            response.Items = await Ordering(filters, categories, !(bool)filters.Download!).ToListAsync(); 
            return response;
        }

        //devolcer todas las categorias
        public async Task<IEnumerable<Category>> ListSelectCategories() { 
        
            var categories= await _context.Categories
                 .Where(x=>x.State.Equals((int)StateTypes.Active) && x.AuditDeleteUser==null && x.AuditDeleteDate==null).AsNoTracking().ToListAsync();
            return categories;
        }

        //devolver un registtro
        public async Task<Category> CategoryById(int CategoryId)
        {
            var category= await _context.Categories!.AsNoTracking().FirstOrDefaultAsync(x=>x.CategoryId.Equals(CategoryId));
            return category!;
        }
        //
        public async Task<bool> RegisterCategory(Category category)
        {
            //sera donamico en un framweok
            category.AuditCreateUser = 1;
            category.AuditCreateDate=DateTime.Now;

            await _context.AddAsync(category);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> EditCategory(Category category)
        {
            category.AuditUpdateUser = 1;
            category.AuditUpdateDate = DateTime.Now;

            _context.Update(category);
            //lo que nos quermeos que se actualizen
            //inorara los campos a dicha category
            _context.Entry(category).Property(x => x.AuditCreateUser).IsModified = false;
            _context.Entry(category).Property(x => x.AuditCreateDate).IsModified = false;

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;

        }

        public async Task<bool> RemoveCategory(int CategoryId)
        {
            var category = await _context.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.CategoryId.Equals(CategoryId));

            category!.AuditDeleteUser = 1;
            category.AuditDeleteDate = DateTime.Now;

            _context.Update(category);

            var recordAffected=  await _context.SaveChangesAsync();
            return recordAffected > 0;
        }
    }
}
