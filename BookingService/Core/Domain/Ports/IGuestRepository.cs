using Domain.DomainEntities;

namespace Domain.Ports
{
    public interface IGuestRepository
    {
        Task<Guest> Get(int Id);
        Task<int> Save(int Id);
    }
}
