using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using VideoRentalApp.Contexts;
using VideoRentalApp.Exceptions;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;
using System;
using System.Linq;

namespace ERentalTesting
{
    [TestFixture]
    public class AddPaymentTesting
    {
        private IPaymentRepository paymentRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbTestAddPayments")
                                .Options;

            MovieContext context = new MovieContext(dbOptions);
            paymentRepository = new PaymentRepository(context);
        }

        [Test]
        public void AddPayment_Success()
        {
            // Arrange
            var payment = new Payment
            {
                CardNumber = "1234567812345678",
                ExpiryDate = "12/25",
                CVV = "123",
                PaymentAmount = 100.00f,
                PaymentDate = DateTime.Now
            };

            // Act
            var result = paymentRepository.AddPayment(payment);

            // Assert
            Assert.AreEqual("Payment done successfully", result);
        }


    }
}
