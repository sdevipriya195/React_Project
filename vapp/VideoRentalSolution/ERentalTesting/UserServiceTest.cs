using System.Text;
using System;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using VideoRentalApp.Contexts;
using Microsoft.EntityFrameworkCore;
using VideoRentalApp.Repositories;
using Microsoft.Extensions.Configuration;
using VideoRentalApp.Services;
using VideoRentalApp.Models.DTOs;
using NUnit.Framework.Internal;



namespace ERentalTesting
{
    public class UserServiceTest
    {
        IRepository<string, User> repository;
        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            MovieContext context = new MovieContext(dbOptions);
            repository = new UserRepository(context);

        }

        [Test]
        [TestCase("Test", "Test@", "test123")]
        //[TestCase("Test", "Test@", "test321")]
        public void LoginTest(string un, string pass, string em)
        {

            //Arrange
            var appSettings = @"{""SecretKey"": ""Anything will work here this is just for testing""}";
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettings)));
            var tokenService = new TokenService(configurationBuilder.Build());
            IUserService userService = new UserService(repository, tokenService);
            userService.Register(new UserDTO
            {
                Username = un,
                Password = pass,
                Email = em,
                Role = "Admin"
            });
            //Action
            var result = userService.Login(new UserDTO { Username = "Test", Email = "Test@", Password = "test123", Role = "Admin" });
            // Assert.AreEqual("Test", result.Username);
            //Assert.AreEqual("Test@", result.Email);

        }
    }

}

