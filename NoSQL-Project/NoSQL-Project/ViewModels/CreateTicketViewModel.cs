using System.ComponentModel.DataAnnotations;

namespace NoSQL_Project.ViewModels
{
    /// ViewModel for creating a new ticket
    public class CreateTicketViewModel
    {
        [Required(ErrorMessage = "Subject is required")]
        [StringLength(100, ErrorMessage = "Subject cannot exceed 100 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Reporter")]
        public string OwnerId { get; set; }

        public string Priority { get; set; } = "Medium";

        public string Type { get; set; } = "General";
    }
}