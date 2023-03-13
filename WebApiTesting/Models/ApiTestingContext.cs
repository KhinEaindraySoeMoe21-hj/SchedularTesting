using Microsoft.EntityFrameworkCore;

namespace WebApiTesting.Models
{
    public class ApiTestingContext : DbContext
    {
        public ApiTestingContext(DbContextOptions<ApiTestingContext> options)
       : base(options)
        {

        }
        public DbSet<BirthdayWishInfo>BirthdayWishInfos { get; set; } = null!;
        public DbSet<NotificationTemplate>NotificationTemplates { get; set; } = null!;
        public DbSet<Employee>Employees { get; set; } = null!;

    }
}
