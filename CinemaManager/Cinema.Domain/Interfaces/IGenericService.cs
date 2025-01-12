using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Interfaces
{
    public interface IGenericService<TEntities, TDTO> where TEntities : class where TDTO : class
    {
        Task AddAsync(TDTO dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(TDTO dto);
    }
}
