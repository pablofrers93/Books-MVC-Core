using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books2023.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage ="The field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [Range(1,100, ErrorMessage = "The field {0} must be between {1} and {2}")]
        [DisplayName("Display Order")]
        public string DisplayOrder { get; set; }
    }
}
