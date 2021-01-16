using System;
using System.ComponentModel.DataAnnotations;

namespace NtemtemApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public string Timezone { get; set; }

        [Required]
        public string Purpose { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}