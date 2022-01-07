using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using TravelApiSql.Data;
using TravelApiSql.Interfaces;
using TravelApiSql.Models;

namespace TravelApiSql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "BadRequest")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "InternalServerError")]
    [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, Description = "ServiceUnavailable")]
    public class TravelPlanController : ControllerBase
    {
        private readonly IEfRepository efRepository;

        public TravelPlanController(IEfRepository efRepository)
        {
            this.efRepository = efRepository;
        }

        /// <summary>
        /// Get a list of destinations
        /// </summary>
        /// <param></param>
        /// <returns>A newly created destination list </returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /travelplan
        ///
        /// </remarks>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<Destination>), Description = "Succeed")]
        public async Task<ActionResult<List<Destination>>> Get()
        {
            return await this.efRepository.GetDestinationListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Create a destination
        /// </summary>
        /// <param></param>
        /// <returns>A newly created destination</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /travelplan
        ///     {
        ///        "country": "New Zealand",
        ///        "city": "Nelson",
        ///        "food": "Wine",
        ///        "sightSeeing": "Malborough"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Destination), Description = "Succeed")]
        public async Task<IActionResult> Post([FromBody] Destination destination)
        {
            Destination addedDestination = await this.efRepository.AddDestinationAsync(destination).ConfigureAwait(false);

            return this.Created("destination", addedDestination);
        }
    }
}
