using Manuais_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manuais_Data.Repositories.Interfaces
{
    public interface IManuaisRepository
    {
        Task<IQueryable<Manuais>> GetAll();
        Task<IQueryable<Manuais>> GetAllById(int id);
        Task<Manuais> InsertOrUpdate(Manuais manuais);
        Task<Manuais> Delete(int id);
    }
}
