using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using VideoRentalApp.Contexts;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    [TestFixture]
    public class DeleteMovieTesting
    {
        private IMovieRepository _movieRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbTestMovie") // Database created temporarily for testing purposes
                                .Options;
            var movieContext = new MovieContext(dbOptions);
            _movieRepository = new MovieRepository(movieContext);
        }

        [Test]
        public void DeleteMovie_WithValidId_ShouldRemoveMovieFromDatabase()
        {
            // Arrange
            var movieToAdd = new Movie
            {
                MovieId = 1,
                GenreName = "Action",
                MovieName = "Test Movie",
                DiscNumber = 123,
                Image = "test-image.jpg",
                MovieDescription = "This is a test movie",
                MovieDuration = 120,
                MovieRating = 4.5,
                MovieRentalCost = 5
            };

            _movieRepository.AddMovie(movieToAdd); // Add a movie to the database

            // Act
            var result = _movieRepository.DeleteMovie(1); // Delete the movie by its ID

            // Assert
            Assert.AreEqual("movie removed from database", result);

            var deletedMovie = _movieRepository.GetMovieById(1); // Try to retrieve the movie after deletion
            Assert.IsNull(deletedMovie, "Movie should be null as it was deleted");
        }

        [Test]
        public void DeleteMovie_WithInvalidId_ShouldReturnMovieNotAvailableMessage()
        {
            // Act
            var result = _movieRepository.DeleteMovie(999); // Try to delete a movie with an invalid ID

            // Assert
            Assert.AreEqual("movie is not available", result);
        }
    }
}

