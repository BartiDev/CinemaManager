using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Interfaces
{
    public interface IReadServiceAsync<TEntity, TDTO> where TEntity : class where TDTO : class
    {
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> GetByIdAsync(int id);
    }
}
