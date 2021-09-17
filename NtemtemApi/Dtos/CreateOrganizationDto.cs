using System.ComponentModel.DataAnnotations;

namespace NtemtemApi.Dtos
{
    public record CreateOrganizationDto(
        [Required][StringLength(100)] string Name,
        [Required] string Details,
        [Required][StringLength(20)] string Phone,
        [Required][StringLength(100)] string Country,
        [Required] string City,
        [Required] string Address
    );
}