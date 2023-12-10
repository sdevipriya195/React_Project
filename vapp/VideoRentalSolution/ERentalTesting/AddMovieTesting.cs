using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VideoRentalApp.Contexts;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    [TestFixture]
    public class AddMovieTesting
    {
        private MovieRepository _movieRepository;
        private MovieContext _context;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase("dbTestMovies") // In-memory database for testing
                .Options;

            _context = new MovieContext(dbOptions);
            _movieRepository = new MovieRepository(_context);
        }

        [Test]
        public void AddMovie_ShouldInsertMovieSuccessfully()
        {
            // Arrange
            var movie = new Movie
            {
                MovieId = 1,
                GenreName = "Action",
                MovieName = "Test Movie",
                DiscNumber = 123,
                Image = "test-image.jpg",
                MovieDescription = "A test movie",
                MovieDuration = 120,
                MovieRating = 4.5,
                MovieRentalCost = 5
            };

            // Act
            var result = _movieRepository.AddMovie(movie);

            // Assert
            Assert.AreEqual("Movie inserted successfully", result);
            Assert.AreEqual(1, _context.movies.Count());
            Assert.AreEqual("Test Movie", _context.movies.First().MovieName);
        }

        [Test]
        public void AddMovie_ShouldReturnErrorMessageForDuplicateDiscNumber()
        {
            // Arrange
            var existingMovie = new Movie
            {
                MovieId = 1,
                GenreName = "Action",
                MovieName = "Existing Movie",
                DiscNumber = 123,
                Image = "existing-image.jpg",
                MovieDescription = "An existing movie",
                MovieDuration = 120,
                MovieRating = 4.0,
                MovieRentalCost = 4
            };

            _context.movies.Add(existingMovie);
            _context.SaveChanges();

            var newMovie = new Movie
            {
                MovieId = 2,
                GenreName = "Comedy",
                MovieName = "Duplicate Disc Movie",
                DiscNumber = 123, // Duplicate DiscNumber
                Image = "duplicate-image.jpg",
                MovieDescription = "A movie with a duplicate DiscNumber",
                MovieDuration = 90,
                MovieRating = 3.8,
                MovieRentalCost = 3
            };

            // Act
            var result = _movieRepository.AddMovie(newMovie);

            // Assert
            Assert.AreEqual("DiscNumber must be unique. Another movie with the same DiscNumber already exists.", result);
            Assert.AreEqual(1, _context.movies.Count()); // Ensure only the existing movie is in the database
        }
    }
}

