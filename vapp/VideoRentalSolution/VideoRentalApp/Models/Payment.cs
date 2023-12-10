using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoRentalApp.Models
{
    /// <summary>
    /// this is Payment Class
    /// </summary>
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public float PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int RentalId { get; set; }
        [ForeignKey("RentalId")]
        public Rental? Rental { get; set; }
    }
}