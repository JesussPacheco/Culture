using System.Threading.Tasks;
using Culture.Domain.Models;

namespace Culture.Domain.Repositories
{
    public interface IHotelRepository
    {
        Task AddAsync(Hotel hotel);
        Task<Hotel> FindByIdAsync(int id);
        void Update(Hotel hotel);
    }
}