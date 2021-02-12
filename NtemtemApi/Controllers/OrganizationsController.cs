using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NtemtemApi.Dtos;
using NtemtemApi.Models;
using NtemtemApi.Services;

namespace NtemtemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly OrganizationService _organizationService;

        public OrganizationsController(OrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Organization>>> GetAllAsync() => await _organizationService.FindAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetById(int id)
        {
            try
            {
                return await _organizationService.FindOneByIdAsync(id);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrganizationDto createOrganizationDto)
        {
            var organization = await _organizationService.CreateAsync(createOrganizationDto);

            return CreatedAtAction(nameof(GetById), new { id = organization.Id }, organization);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _organizationService.DeleteOneByIdAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/appointments")]
        public async Task<ActionResult<List<Appointment>>> GetAllAppointmentsAsync(int id)
        {
            try
            {
                return await _organizationService.FindAllAppointmentsForOrganizationAsync(id);
            }
            catch
            {
                return NotFound();
            }
        }

    }
}