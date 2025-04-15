using System.ComponentModel.DataAnnotations;

namespace TravelExperienceCoreAPI.DTOs
{
    public class RequestDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string User { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        public List<ActivityDTO> Activities { get; set; }
    }
}
