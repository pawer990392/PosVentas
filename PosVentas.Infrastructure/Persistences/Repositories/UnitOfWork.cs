using PosVentas.Infrastructure.Persistences.Contexts;
using PosVentas.Infrastructure.Persistences.Interfaces;

namespace PosVentas.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly PosContext _context;
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(PosContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }
        //objetos en memoria

            public void Dispose()
        {
           _context.Dispose();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
