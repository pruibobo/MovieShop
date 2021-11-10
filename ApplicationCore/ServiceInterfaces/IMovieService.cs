using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<MovieCardResponseModel> GetTopRevenueMovies();
        Task<MovieDetailsResponseModel> GetMovieDetails(int id);
        Task<List<MovieCardResponseModel>> GetMovieByGenreId(int id);
        Task<List<MovieCardResponseModel>> GetMoviesAsync();
        Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        Task<List<ReviewResponseModel>> GetReviewsByMovieId(int movieId);
        Task<CreateMovieRequestModel> CreateMovie(CreateMovieRequestModel createMovieRequestModel);
        Task<CreateMovieRequestModel> UpdateMovie(CreateMovieRequestModel createMovieRequestModel);
        Task<PurchaseResponseModel> GetMoviePurchases(PurchaseResponseModel purchaseResponseModel);
    }
}
