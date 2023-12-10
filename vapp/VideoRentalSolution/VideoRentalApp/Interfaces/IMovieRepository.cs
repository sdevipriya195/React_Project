using VideoRentalApp.Models;

namespace VideoRentalApp.Interfaces
{
    public interface IMovieRepository
    {
        /// <summary>
        /// This is interface for movie class
        /// </summary>
        /// <param name="key">It is ID for movie class</param>
        /// <returns>It provides interface for all crud operations</returns>
        Movie GetMovieById(int key);
        List<Movie> GetAllMovies(string genre);
        string AddMovie(Movie entity);
        string UpdateMovie(Movie entity);
        string DeleteMovie(int key);
    }
}