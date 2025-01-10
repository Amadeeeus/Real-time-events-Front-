using Authorization.Core.Entities;
using Authorization.Infrastructure.DataAccess;
using Infrastructure.Persistence;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.EntityFrameworkCore;
using Message = Domain.Entities.Message;

namespace Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageDbContext _context;
        private readonly AppDbContext _appcontext;

        public MessageRepository(MessageDbContext context, AppDbContext appcontext)
        {
            _context = context;
            _appcontext = appcontext;
        }

        public async Task<IEnumerable<Message>> GetMessagesByUserIdAsync(string userId)
        {
            return await _context.Messages.Where(m => m.SenderId == userId).ToListAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetUserId(string firstName, string lastName)
        {
            var user =  await _appcontext.Users.FirstOrDefaultAsync(u=>u.FirstName==firstName && u.LastName==lastName);
            return user!.Id;
        }

        public async Task<UserEntity> GetUserDataAsync(string userId)
        {
            var user =  await _appcontext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user!;
        }
    }
}

