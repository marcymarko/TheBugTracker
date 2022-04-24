using System.Collections.Generic;
using System.Threading.Tasks;
using TheBugTracker.Models;

namespace TheBugTracker.Services.Interfaces
{
    public interface IBTLookupService
    {
        public Task<List<TicketPriority>> GetTicketPriorityAsync();

        public Task<List<TicketStatus>> GetTicketStatusAsync();

        public Task<List<TicketType>> GetTicketTypeAsync();

        public Task<List<ProjectPriority>> GetProjectPrioritiesAsync();

    }
}
