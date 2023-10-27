using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books2023.Models.Models
{
    [Index(nameof(Name), IsUnique =  true)]
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 3)]

        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
