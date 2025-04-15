using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelExperienceCoreAPI.Models
{    
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]        
        public string DestinationId { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Duration { get; set; }


        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public decimal Cost { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int TripId { get; set; }

       
    }
}
