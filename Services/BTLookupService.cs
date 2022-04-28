using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBugTracker.Data;
using TheBugTracker.Models;
using TheBugTracker.Services.Interfaces;

namespace TheBugTracker.Services
{
    public class BTLookupService : IBTLookupService
    {
        private readonly ApplicationDbContext _context;

        public BTLookupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectPriority>> GetProjectPrioritiesAsync()
        {
            try
            {
                return await _context.ProjectPriorities.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<List<TicketPriority>> GetTicketPriorityAsync()
        {
            try
            {
                return await _context.TicketPriorities.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<List<TicketStatus>> GetTicketStatusAsync()
        {
            try
            {
                return await _context.TicketStatuses.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<List<TicketType>> GetTicketTypeAsync()
        {
            try
            {
                return await _context.TicketTypes.ToListAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
