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
            return await _context.ProjectPriorities.ToListAsync();
        }

        public Task<List<TicketPriority>> GetTicketPriorityAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TicketStatus>> GetTicketStatusAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TicketType>> GetTicketTypeAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
