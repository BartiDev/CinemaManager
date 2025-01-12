using AutoMapper;
using Cinema.Domain.DTOs;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Mappings
{
    public class MovieMapping : ReadServiceAsync<Movie, MovieDTO>, IMovieMapping
    {
        public MovieMapping(IGenericRepository<Movie> genericRepository,
            IMapper mapper) 
            :base(genericRepository, 
                  mapper)
        {

        }
    }
}
