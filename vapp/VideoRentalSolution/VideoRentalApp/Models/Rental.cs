using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoRentalApp.Models;

namespace VideoRentalApp.Models
{
    public class Rental
    {
        /// <summary>
        /// This is Rental Class
        /// </summary>
        [Key]
        public int RentalId { get; set; }

        [Required]
        public string RentalDate { get; set; }

        public float RentalCost { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
    }
}