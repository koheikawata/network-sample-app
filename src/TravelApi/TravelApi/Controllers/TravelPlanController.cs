using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace TravelApi.Controllers
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
        public TravelPlanController()
        {
        }

        /// <summary>
        /// Get a list of destinations
        /// </summary>
        /// <param></param>
        /// <returns>A newly created destination list</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /travelplan
        ///
        /// </remarks>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<Destination>), Description = "Succeed")]
        public IActionResult Get()
        {
            List<Destination> destinations = new ()
            {
                new Destination() { Country = "France", City = "Paris", Food = "Wine", SightSeeing = "Eiffel Tower" },
                new Destination() { Country = "Japan", City = "Tokyo", Food = "Ramen", SightSeeing = "Skytree" },
            };

            return this.Created("destinations", destinations);
        }
    }
}
