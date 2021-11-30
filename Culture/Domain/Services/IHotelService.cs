using System.Threading.Tasks;
using Culture.Domain.Models;
using Culture.Domain.Services.Communication;

namespace Culture.Domain.Services
{
    public interface IHotelService
    {
        Task<HotelResponse> FindByIdAsync(int id);
        
        Task<HotelResponse> SaveAsync(Hotel hotel);
        
        Task<HotelResponse> UpdateAsync(int id, Hotel hotel);
    }
    
}