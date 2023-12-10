using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using VideoRentalApp.Contexts;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    public class UpdateMovieTesting
    {
        private DbContextOptions<MovieContext> _options;

        [SetUp]
        public void Setup()
        {
            // Set up the in-memory database for testing
            _options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new MovieContext(_options))
            {
                // Seed the database with test data
                context.movies.Add(new Movie
                {
                    MovieId = 1,
                    MovieName = "TestMovie",
                    MovieRating = 3.5,
                    MovieRentalCost = 5
                    // Add other properties as needed for testing
                });
                context.SaveChanges();
            }
        }

        [Test]
        [TestCase(1, 4.0, 8)]
        public void UpdateMovieTest(int movieId, double newRating, int newRentalCost)
        {
            // Arrange
            using (var context = new MovieContext(_options))
            {
                var repository = new MovieRepository(context);

                // Act
                var movieToUpdate = context.movies.Find(movieId);
                var updatedMovie = new Movie
                {
                    MovieId = movieToUpdate.MovieId,
                    MovieRating = newRating,
                    MovieRentalCost = newRentalCost
                    // Add other properties as needed for testing
                };
                var result = repository.UpdateMovie(updatedMovie);

                // Assert
                Assert.AreEqual("movie details updated successfully", result);
                Assert.AreEqual(newRating, movieToUpdate.MovieRating);
                Assert.AreEqual(newRentalCost, movieToUpdate.MovieRentalCost);
                // Add other assertions for properties that should be updated
            }
        }

        [Test]
        [TestCase(2, 4.0, 8)]
        public void UpdateMovieNotFoundTest(int movieId, double newRating, int newRentalCost)
        {
            // Arrange
            using (var context = new MovieContext(_options))
            {
                var repository = new MovieRepository(context);

                // Act
                var result = repository.UpdateMovie(new Movie
                {
                    MovieId = movieId,
                    MovieRating = newRating,
                    MovieRentalCost = newRentalCost
                    // Add other properties as needed for testing
                });

                // Assert
                Assert.AreEqual("movie details are not updated", result);
            }
        }
    }
}

