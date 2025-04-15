using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelExperienceCoreAPI.Models
{    
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string UserId { get; set; }


        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Title { get; set; }


        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }


        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public decimal TotalCost { get; set; }
    }
}
