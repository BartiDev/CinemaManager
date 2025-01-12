using AutoMapper;
using Cinema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Services
{
    public class GenericService<TEntity, TDTO> : ReadServiceAsync<TEntity, TDTO>, IGenericService<TEntity, TDTO>
        where TEntity : class
        where TDTO : class
    {
        public GenericService(IGenericRepository<TEntity> genericRepository,
            IMapper mapper)
            : base(genericRepository, mapper)
        {

        }

        public async Task AddAsync(TDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _genericRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _genericRepository.DeleteByIdAsync(id);
        }

        public async Task UpdateAsync(TDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _genericRepository.UpdateAsync(entity);
        }
    }
}
