using AutoMapper;
using Cinema.Domain.Exceptions;
using Cinema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Services
{
    public class ReadServiceAsync<TEntity, TDTO> : IReadServiceAsync<TEntity, TDTO>
        where TEntity : class
        where TDTO : class
    {
        internal readonly IGenericRepository<TEntity> _genericRepository;
        internal readonly IMapper _mapper;

        public ReadServiceAsync(IGenericRepository<TEntity> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            try
            {
                var result = await _genericRepository.GetAllAsync();

                if (result.Any())
                {
                    var mapperResult = _mapper.Map<IEnumerable<TDTO>>(result);
                    return mapperResult;
                }
                else
                {
                    throw new EntityNotFoundException($"No {typeof(TDTO).Name}s were found");
                }
            }
            catch (EntityNotFoundException e)
            {
                var message = $"Error retrieving all {typeof(TDTO).Name}s";

                throw new EntityNotFoundException(message, e);
            }
        }

        public async Task<TDTO> GetByIdAsync(int id)
        {
            try
            {
                var result = await _genericRepository.GetByIdAsync(id);

                if (result != null)
                {
                    var mapperResult = _mapper.Map<TDTO>(result);
                    return mapperResult;
                }
                else
                {
                    throw new EntityNotFoundException($"Entity with ID {id} not found.");
                }
            }
            catch (EntityNotFoundException e)
            {
                var message = $"Error retrieving {typeof(TDTO).Name} with Id: {id}";

                throw new EntityNotFoundException(message, e);
            }
        }
    }
}
