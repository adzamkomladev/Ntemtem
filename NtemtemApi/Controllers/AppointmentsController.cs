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
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetById(int id)
        {
            try
            {
                return await _appointmentService.FindOneByIdAsync(id);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto createAppointmentDto)
        {
            var appointment = await _appointmentService.CreateAsync(createAppointmentDto);

            return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, appointment);
        }
    }
}