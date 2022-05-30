using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace TheBugTracker.Services
{
    public interface IBlogEmailSender : IEmailSender
    {
        Task SendContactEmailAsync(string emailFrom, string name, string subject, string htmlMessage);
    }
}
