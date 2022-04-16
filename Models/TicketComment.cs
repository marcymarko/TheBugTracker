using System;
using System.ComponentModel;

namespace TheBugTracker.Models
{
    public class TicketComment
    {
        public int Id { get; set; }

        [DisplayName("Member Comment")]
        public string Comment { get; set; }

        [DisplayName("Date")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; }   // FK : This value will have an Id of some ticket that exists in another table

        [DisplayName("Team Member")]
        public string UserId { get; set; }  // FK : represents BTUser. 


        // Navigation properties
        // UserId is related to User; TicketId is related to Ticket
        public virtual Ticket Ticket { get; set; }
        public virtual BTUser User { get; set; }
    }
}
