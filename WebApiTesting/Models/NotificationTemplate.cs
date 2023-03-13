using System.ComponentModel.DataAnnotations;

namespace WebApiTesting.Models
{
    public class NotificationTemplate
    {
        [Key]
        public int NotiTemplateID { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; } 
    }
}
