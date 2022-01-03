using TravelApiSql.Models;

namespace TravelApiSql.Interfaces
{
    public interface IEfRepository
    {
        public Task<List<Destination>> GetDestinationListAsync();
        public Task<Destination> AddDestinationAsync(Destination destination);
    }
}
