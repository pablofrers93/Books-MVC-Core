using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Books2023.Models.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class CoverType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        [DisplayName("Cover Type")]
        public string Name { get; set; }
    }
}
