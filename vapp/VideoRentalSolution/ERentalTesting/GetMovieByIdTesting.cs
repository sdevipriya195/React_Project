using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using VideoRentalApp.Contexts;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    [TestFixture]
    public class GetMovieByIdTesting
    {
        private MovieRepository _movieRepository;
        private MovieContext _context;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase("dbGetMovieByIdTstMovie")
                .Options;

            _context = new MovieContext(dbOptions);
            _movieRepository = new MovieRepository(_context);

            // Seed some test data
            _context.movies.Add(new Movie
            {
                MovieId = 1,
                MovieName = "Movie 1",
                GenreName = "Action",
                DiscNumber = 101,
                Image = "image1.jpg",
                MovieDescription = "Description for Movie 1",
                MovieDuration = 120,
                MovieRating = 4.5,
                MovieRentalCost = 5
            });

            _context.movies.Add(new Movie
            {
                MovieId = 2,
                MovieName = "Movie 2",
                GenreName = "Comedy",
                DiscNumber = 102,
                Image = "image2.jpg",
                MovieDescription = "Description for Movie 2",
                MovieDuration = 110,
                MovieRating = 3.8,
                MovieRentalCost = 4
            });

            _context.SaveChanges();
        }

        [Test]
        [TestCase(1)]

        public void GetMovieById_ValidId_ReturnsMovie(int movieId)
        {
            // Act
            var result = _movieRepository.GetMovieById(movieId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(movieId, result.MovieId);
        }

        [Test]
        [TestCase(100)] // Invalid MovieId

        public void GetMovieById_InvalidId_ReturnsNull(int movieId)
        {
            // Act
            var result = _movieRepository.GetMovieById(movieId);

            // Assert
            Assert.IsNull(result);
        }
    }
}

