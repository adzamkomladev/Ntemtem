using System;
using System.ComponentModel.DataAnnotations;

namespace NtemtemApi.Models
{
    public record Organization(
        int Id,
        [Required][StringLength(100)] string Name,
        [Required] string Details,
        [Required][StringLength(20)] string Phone,
        [Required][StringLength(100)] string Country,
        [Required] string City,
        [Required] string Address,
        string GeographicLocation,
        DateTime? CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt
    );
}