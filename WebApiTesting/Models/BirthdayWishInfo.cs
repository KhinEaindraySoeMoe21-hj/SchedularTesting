using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace WebApiTesting.Models
{
    public class BirthdayWishInfo
    {
        [Key]
        public int BirthdayNotiID { get; set; }
        public string? UserName  { get; set; }
        public DateTime UserBd { get; set; }
        public bool IsPreBd { get; set; } = false;
        public bool IsBd { get; set; } = false;

    }
}
