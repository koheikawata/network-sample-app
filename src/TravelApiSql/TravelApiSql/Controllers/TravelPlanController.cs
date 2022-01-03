using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApiSql.Data;
using TravelApiSql.Interfaces;
using TravelApiSql.Models;

namespace TravelApiSql.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TravelPlanController : ControllerBase
    {
        private readonly IEfRepository efRepository;

        public TravelPlanController(IEfRepository efRepository)
        {
            this.efRepository = efRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Destination>>> Get()
        {
            return await this.efRepository.GetDestinationListAsync().ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Destination destination)
        {
            Destination addedDestination = await this.efRepository.AddDestinationAsync(destination).ConfigureAwait(false);

            return this.Created("destination", addedDestination);
        }
    }
}
