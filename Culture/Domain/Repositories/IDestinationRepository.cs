using System.Threading.Tasks;
using Culture.Domain.Models;

namespace Culture.Domain.Repositories
{
    public interface IDestinationRepository
    {
        Task AddAsync( Destination destination);
        Task<Destination> FindByIdAsync(int id);
    }
}