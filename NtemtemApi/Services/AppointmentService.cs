using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NtemtemApi.Data;
using NtemtemApi.Dtos;
using NtemtemApi.Models;

namespace NtemtemApi.Services
{
    public class AppointmentService
    {
        private readonly NtemtemApiContext _context;
        public AppointmentService(NtemtemApiContext context)
        {
            _context = context;
        }

        public async Task<Appointment> FindOneByIdAsync(int id)
        {

            var appointment = await _context.Appointments.FirstOrDefaultAsync(m => m.Id == id);

            if (appointment == null)
            {
                throw new NullReferenceException();
            }

            return appointment;
        }

        public async Task<Appointment> CreateAsync(CreateAppointmentDto createAppointmentDto)
        {
            var (start, end, timezone, purpose, location, organizationId) = createAppointmentDto;
            var appointment = new Appointment
            {
                Start = start,
                End = end,
                Timezone = timezone,
                Purpose = purpose,
                Location = location,
                Status = "PENDING",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var organization = await _context.Organizations
            .Include(o => o.Appointments)
            .FirstOrDefaultAsync(o => o.Id == organizationId);

            if (organization == null)
            {
                throw new NullReferenceException();
            }

            organization.Appointments.Add(appointment);

            await _context.SaveChangesAsync();

            return organization.Appointments
            .LastOrDefault();
        }
    }
}