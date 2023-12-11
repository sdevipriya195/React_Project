using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalApp.Contexts;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;

namespace ERentalTesting
{
    [TestFixture]
    public class GetAllPaymentTesting
    {
        private IPaymentRepository paymentRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<MovieContext>()
                                .UseInMemoryDatabase("dbGetAllTestPayments")
                                .Options;

            MovieContext context = new MovieContext(dbOptions);
            paymentRepository = new PaymentRepository(context);
        }
        [Test]
        public void GetAllPayments_Success()
        {
            // Arrange
            var payment1 = new Payment
            {
                CardNumber = "1234567812345678",
                ExpiryDate = "12/25",
                CVV = "123",
                PaymentAmount = 100.00f,
                PaymentDate = DateTime.Now
            };

            var payment2 = new Payment
            {
                CardNumber = "5678123456781234",
                ExpiryDate = "01/26",
                CVV = "456",
                PaymentAmount = 150.00f,
                PaymentDate = DateTime.Now.AddDays(1)
            };

            // Add payments
            paymentRepository.AddPayment(payment1);
            paymentRepository.AddPayment(payment2);

            // Act
            var allPayments = paymentRepository.GetAllPayments();

            // Assert
            Assert.AreEqual(2, allPayments.Count);
        }
    }
}
