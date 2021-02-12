using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using NtemtemApi.Data;
using NtemtemApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using NtemtemApi.Dtos;

namespace NtemtemApi.Services
{
    public class OrganizationService
    {
        private readonly NtemtemApiContext _context;
        public OrganizationService(NtemtemApiContext context)
        {
            _context = context;
        }

        public Task<List<Organization>> FindAllAsync() => _context.Organizations.ToListAsync();

        public bool Exists(int id) => _context.Organizations.Any(e => e.Id == id);

        public async Task<Organization> FindOneByIdAsync(int id)
        {

            var organization = await _context.Organizations.FirstOrDefaultAsync(m => m.Id == id);

            if (organization == null)
            {
                throw new NullReferenceException();
            }

            return organization;
        }

        public async Task<Organization> CreateAsync(CreateOrganizationDto createOrganizationDto)
        {
            var (name, details, phone, country, city, address) = createOrganizationDto;
            var organization = new Organization
            {
                Id = 0,
                Name = name,
                Details = details,
                Phone = phone,
                Country = country,
                City = city,
                Address = address,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            return organization;
        }
        public async Task DeleteOneByIdAsync(int id)
        {
            var organization = await FindOneByIdAsync(id);

            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> FindAllAppointmentsForOrganizationAsync(int id)
        {
            var organization = await _context.Organizations
            .Include(o => o.Appointments)
            .FirstOrDefaultAsync(m => m.Id == id);

            if (organization == null)
            {
                throw new NullReferenceException();
            }

            return organization.Appointments;
        }

    }
}