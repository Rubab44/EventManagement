using System.ComponentModel.DataAnnotations;

namespace BlazorAuthPolicy.Models.ViewModels
{
    public class EventCategoryViewModel
    {
        [Required]
        public string? Name { get; set; }
    }
}
