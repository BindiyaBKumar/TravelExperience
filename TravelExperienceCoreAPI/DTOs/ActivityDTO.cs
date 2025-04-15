using System.ComponentModel.DataAnnotations;

namespace TravelExperienceCoreAPI.DTOs
{
    public class ActivityDTO
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string DestinationId { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]        
        public int Duration { get; set; }


        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public decimal Cost { get; set; }

    }
}
