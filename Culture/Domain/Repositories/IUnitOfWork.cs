using System.Threading.Tasks;

namespace Culture.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}