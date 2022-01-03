using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;

namespace TravelApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TravelPlanController : ControllerBase
    {
        public TravelPlanController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Destination> destinations = new()
            {
                new Destination() { Country = "France", City = "Paris", Food = "Wine", SightSeeing = "Eiffel Tower" },
                new Destination() { Country = "Japan", City = "Tokyo", Food = "Ramen", SightSeeing = "Skytree" },
            };

            return this.Created("destinations", destinations);
        }
    }
}
