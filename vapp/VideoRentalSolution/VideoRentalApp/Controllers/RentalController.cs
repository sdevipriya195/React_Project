using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using VideoRentalApp.Repositories;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol.Core.Types;
using VideoRentalApp.Controllers;
using Microsoft.AspNetCore.Cors;

namespace VideoRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]

    public class RentalController : ControllerBase
    {
        private readonly IRentalRepository _rentalRepository = null;
        private readonly ILogger<RentalController> _logger;


        public RentalController(IRentalRepository rentalRepository, ILogger<RentalController> logger)
        {
            _rentalRepository = rentalRepository;
            _logger = logger;
        }
        /// <summary>
        /// Get the Rental details of a movie
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        //[Authorize]
        public ActionResult<List<Rental>> Get()
        {
            List<Rental> Rentals = _rentalRepository.GetAllRentals();
            if (Rentals.Count > 0)
            {
                return Rentals;
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Get the Rental details by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        //[Authorize]
        public ActionResult<Rental> Get(int id)
        {
            Rental Rentals = _rentalRepository.GetRentalById(id);
            if (Rentals != null)
            {
                return Rentals;
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Add the rentals of the movie
        /// </summary>
        /// <param name="Rentals"></param>
        /// <returns></returns>

        [HttpPost]
       // [Authorize(Roles = "Admin")]

        public string Post(Rental Rentals)
        {
            try
            {
                string Response = _rentalRepository.AddRental(Rentals);
                return Response;
            }
            catch (Exception ex)
            {

                _logger.LogError("Unable to update the rental to this movie");

                return (ex.InnerException.Message);
            }
        }
        /// <summary>
        /// Update the rental details
        /// </summary>
        /// <param name="Rentals"></param>
        /// <returns></returns>
        [HttpPut]
       // [Authorize(Roles = "Admin")]

        public string Put(Rental Rentals)
        {
            try
            {
                string Response = _rentalRepository.UpdateRental(Rentals);
                return Response;
            }
            catch (Exception ex)
            {

                _logger.LogError("Please enter the correct rental fields");

                return (ex.InnerException.Message);
            }
        }
        /// <summary>
        /// Delete the rental details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [Route("{id:int}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]

        public string Delete(int id)
        {
            try
            {
                string Response = _rentalRepository.DeleteRental(id);
                return Response;
            }
            catch (Exception ex)
            {

                _logger.LogError("Unable to delete this rental");

                return (ex.InnerException.Message);
            }
        }
    }
}