using System;
using System.ComponentModel.DataAnnotations;

namespace NtemtemApi.Dtos
{
        public record CreateAppointmentDto(
        [Required] DateTime Start,
        [Required] DateTime End,
        [Required] string Timezone,
        [Required] string Purpose,
        [Required] string Location,
        [Required] int OrganizationId
    );
}