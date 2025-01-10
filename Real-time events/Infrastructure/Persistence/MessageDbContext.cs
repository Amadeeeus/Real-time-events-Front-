using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MessageDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options) { }
    }
}