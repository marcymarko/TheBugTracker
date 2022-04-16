using System;
using System.ComponentModel;

namespace TheBugTracker.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; }  // FK : This value will have an Id of some ticket that exists in another table

        [DisplayName("Updated Item")]
        public string Property { get; set; }

        [DisplayName("Previous")]
        public string OldValue { get; set; }

        [DisplayName("Current")]
        public string NewValue { get; set; }

        [DisplayName("Date Modified")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Description of Change")]
        public string Description { get; set; }

        [DisplayName("Team Member")]
        public string UserId { get; set; }  // FK : represents BTUser. 

        
        // Navigation properties
        // UserId is related to User; TicketId is related to Ticket
        public virtual Ticket Ticket { get; set; }
        public virtual BTUser User { get; set; }
    }
}
