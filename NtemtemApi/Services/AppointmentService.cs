using NtemtemApi.Data;

namespace NtemtemApi.Services
{
    public class AppointmentService
    {
        private readonly NtemtemApiContext _context;
        public AppointmentService(NtemtemApiContext context)
        {
            _context = context;
        }
    }
}