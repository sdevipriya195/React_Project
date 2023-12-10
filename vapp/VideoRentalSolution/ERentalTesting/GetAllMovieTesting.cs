using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VideoRentalApp.Contexts;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    public class GetAllMovieTesting
    {
        private IMovieRepository _movieRepository;

        [SetUp]
        public void Setup()
        {
            // Set up the database context and repository for testing
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbTestMovie") // Use a different database for testing
                                .Options;
            MovieContext context = new MovieContext(dbOptions);
            _movieRepository = new MovieRepository(context);

            // Seed some test data
            _movieRepository.AddMovie(new Movie
            {
                MovieName = "Movie1",
                GenreName = "Action",
                DiscNumber = 1,
                Image = "image1.jpg",
                MovieDescription = "Description1",
                MovieDuration = 120,
                MovieRating = 4.5,
                MovieRentalCost = 5
            });

            _movieRepository.AddMovie(new Movie
            {
                MovieName = "Movie2",
                GenreName = "Drama",
                DiscNumber = 2,
                Image = "image2.jpg",
                MovieDescription = "Description2",
                MovieDuration = 150,
                MovieRating = 3.8,
                MovieRentalCost = 6
            });
        }

        [Test]
        public void GetAllMovies_ReturnsAllMovies()
        {
            // Arrange

            // Action
            List<Movie> movies = _movieRepository.GetAllMovies(null);

            // Assert
            Assert.IsNotNull(movies);
            Assert.AreEqual(2, movies.Count);
        }

        [Test]
        public void GetAllMovies_ReturnsFilteredMoviesByGenre()
        {
            // Arrange

            // Action
            List<Movie> actionMovies = _movieRepository.GetAllMovies("Action");
            List<Movie> dramaMovies = _movieRepository.GetAllMovies("Drama");

            // Assert
            Assert.IsNotNull(actionMovies);
            Assert.AreEqual(1, actionMovies.Count);

            Assert.IsNotNull(dramaMovies);
            Assert.AreEqual(1, dramaMovies.Count);
        }

        [Test]
        public void GetAllMovies_ReturnsEmptyListForUnknownGenre()
        {
            // Arrange

            // Action
            List<Movie> sciFiMovies = _movieRepository.GetAllMovies("Sci-Fi");

            // Assert
            Assert.IsNotNull(sciFiMovies);
            Assert.AreEqual(0, sciFiMovies.Count);
        }
    }
}

