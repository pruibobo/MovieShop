using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<List<Movie>> GetTop30RevenueMovies();
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Review>> GetReviewByMovie(int id);

    }
}
