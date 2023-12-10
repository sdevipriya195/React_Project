using VideoRentalApp.Contexts;
using VideoRentalApp.Models;
using System;
using VideoRentalApp.Interfaces;

namespace VideoRentalApp.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        MovieContext _context;
        public MovieRepository(MovieContext context)
        {
            _context = context;
        }
        public string AddMovie(Movie movie)
        {
            try
            {
                // Check if a movie with the same DiscNumber already exists
                if (_context.movies.Any(m => m.DiscNumber == movie.DiscNumber))
                {
                    return "DiscNumber must be unique. Another movie with the same DiscNumber already exists.";
                }

                int count = _context.movies.Count();
                _context.movies.Add(movie);
                _context.SaveChanges();
                int newcount = _context.movies.Count();
                if (newcount > count)
                {
                    return "Movie inserted successfully";
                }
                else
                {
                    return "Oops, something went wrong while inserting";
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error in AddMovie: {ex.Message}");
                return "Failed to insert movie. Please try again later.";
            }
        }


        public string DeleteMovie(int id)
        {
            Movie movie = _context.movies.Find(id);
            if (movie != null)
            {
                _context.movies.Remove(movie);
                _context.SaveChanges();
                return "movie removed from database";
            }
            else
            {
                return "movie is not available";
            }

        }
        public List<Movie> GetAllMovies(string genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                // If no genre is specified, return all movies
                return _context.movies.ToList();
            }
            else
            {
                // Filter movies by genre
                return _context.movies.Where(m => m.GenreName.ToLower() == genre.ToLower()).ToList();
            }
        }

        public string UpdateMovie(Movie newmovie)
        {
            Movie movie = _context.movies.FirstOrDefault(d =>
            d.MovieId == newmovie.MovieId);
            if (movie != null)
            {
                movie.MovieRating = newmovie.MovieRating;
                movie.MovieRentalCost = newmovie.MovieRentalCost;

                _context.SaveChanges();
                return "movie details updated successfully";

            }
            else
            {
                return "movie details are not updated";
            }

        }
        public Movie GetMovieById(int id)
        {
            Movie movie = _context.movies.Find(id);
            return movie;
        }
    }
}