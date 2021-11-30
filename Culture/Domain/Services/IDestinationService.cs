using System.Threading.Tasks;
using Culture.Domain.Models;
using Culture.Domain.Services.Communication;

namespace Culture.Domain.Services
{
    public interface IDestinationService
    {
        
        
        
        Task<DestinationResponse> SaveAsync(Destination destination);
        Task<DestinationResponse> FindByIdAsync(int id);

    }
}