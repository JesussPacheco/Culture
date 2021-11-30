using System.Threading.Tasks;
using Culture.Domain.Models;
using Culture.Domain.Repositories;
using Culture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Culture.Repositories
{
    public class HotelRepository:BaseRepository,IHotelRepository
    {
        public HotelRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
        }

        public async  Task<Hotel> FindByIdAsync(int id)
        {
            return await _context.Hotels
                .Include(p => p.Destination)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
        }
    }
}