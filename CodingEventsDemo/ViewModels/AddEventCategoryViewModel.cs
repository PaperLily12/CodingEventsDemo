using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
