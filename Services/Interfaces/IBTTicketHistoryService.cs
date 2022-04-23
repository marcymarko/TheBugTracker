using System.Collections.Generic;
using System.Threading.Tasks;
using TheBugTracker.Models;

namespace TheBugTracker.Services.Interfaces
{
    public interface IBTTicketHistoryService
    {
        public Task AddHistoryAsync(Ticket oldTicket, Ticket newTicket, string UserId);

        public Task<List<TicketHistory>> GetProjectTicketsHistoriesAsync(int projectId, int companyId);

        public Task<List<TicketHistory>> GetCompanyTicketsHistoriesAsync(int companyId);
    }
}
