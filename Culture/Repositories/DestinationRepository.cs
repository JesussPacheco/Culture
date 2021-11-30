using System.Threading.Tasks;
using Culture.Domain.Models;
using Culture.Domain.Repositories;
using Culture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Culture.Repositories
{
    public class DestinationRepository:BaseRepository,IDestinationRepository
    {
        public DestinationRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(Destination destination)
        {
            await _context.Destinations.ToListAsync();
        }

        public  async Task<Destination> FindByIdAsync(int id)
        {
            return await _context.Destinations.FindAsync(id);
        }

       
    }
}