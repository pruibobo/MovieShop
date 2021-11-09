using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IReviewRepository : IAsyncRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewByUserId(int userId);
        Task<IEnumerable<Review>> GetReviewByMovieId(int movieId);
        void AddReviewWithUserId(int userId, Review review);
        void UpdateReviewWithUserId(int userId, Review review);
        Task<bool> SaveAsync();

    }
}
