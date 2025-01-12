using AutoMapper;
using Cinema.Domain.DTOs;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Services
{
    public class MovieService : ReadServiceAsync<Movie, MovieDTO>, IMovieService
    {
        public MovieService(IGenericRepository<Movie> genericRepository,
            IMapper mapper)
            : base(genericRepository,
                  mapper)
        {

        }
    }
}
