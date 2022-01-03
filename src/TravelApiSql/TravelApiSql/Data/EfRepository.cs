using Microsoft.EntityFrameworkCore;
using TravelApiSql.Interfaces;
using TravelApiSql.Models;

namespace TravelApiSql.Data
{
    public class EfRepository : IEfRepository
    {
        private readonly TravelContext travelContext;

        public EfRepository(TravelContext travelContext)
        {
            this.travelContext = travelContext;
        }

        public async Task<List<Destination>> GetDestinationListAsync()
        {
            return await this.travelContext.Destinations.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Destination> AddDestinationAsync(Destination destination)
        {
            await this.travelContext.Destinations.AddAsync(destination).ConfigureAwait(false);
            await this.travelContext.SaveChangesAsync().ConfigureAwait(false);

            return destination;
        }
    }
}
