using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Rated { get; set; }
        public string? Released { get; set; }
        public string? Runtime { get; set; }
        public string Genre { get; set; } = null!;
        public string? Director { get; set; }
        public string? Writer { get; set; }
        public string? Actors { get; set; }
        public string Plot { get; set; } = null!;
        public string? Country { get; set; }
        public string? Awards { get; set; }
        public string? Poster { get; set; }
        public decimal? ImdbRating { get; set; }
        public string? BoxOffice { get; set; }
    }
}
