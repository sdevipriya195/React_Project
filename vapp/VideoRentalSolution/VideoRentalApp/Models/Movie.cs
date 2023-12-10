using System.ComponentModel.DataAnnotations;
using VideoRentalApp.Models;

namespace VideoRentalApp.Models
{
    /// <summary>
    /// this is Movie Class
    /// </summary>
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string GenreName { get; set; }
        [Required]
        public string MovieName { get; set; }
        public int DiscNumber { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string MovieDescription { get; set; }
        public int MovieDuration { get; set; }
        public double MovieRating { get; set; }
        public int MovieRentalCost { get; set; }
    }
}