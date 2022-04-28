using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheBugTracker.Extensions;

namespace TheBugTracker.Models
{
    public class TicketAttachment
    {
        public int Id { get; set; }

        [DisplayName("Ticket")]
        public int TicketId { get; set; }  // FK : This value will have an Id of some ticket that exists in another table

        [DisplayName("File Date")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Team Member")]
        public string UserId { get; set; }  // FK : represents BTUser.

        [DisplayName("File Description")]
        public string Description { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [Display(Name = "Select a File")]
        [MaxFileSize(1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".ppt", ".pptx", ".html" })]
        public IFormFile FormFile { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        [DisplayName("File Extension")]
        public string FileContentType { get; set; }



        // Navigation properties
        // UserId is related to User; TicketId is related to Ticket
        public virtual Ticket Ticket { get; set; }
        public virtual BTUser User { get; set; }
    }
}
