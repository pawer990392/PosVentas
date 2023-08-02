using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosVentas.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //dECLARACION O MATRICULA DE NUESTRA INTEFACES A NIVEL DE REPOSITORY
        ICategoryRepository Category { get;}

        void SaveChanges();
        Task SaveChangeAsync();


    }
}
