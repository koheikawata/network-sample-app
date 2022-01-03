using TravelApiSql.Models;

namespace TravelApiSql.Data
{
    public class DbInitializer
    {
        public static void Initialize(TravelContext context)
        {
            context.Database.EnsureCreated();

            if (context.Destinations.Any())
            {
                return;
            }

            var destinations = new Destination[]
            {
                new Destination{Country="France",City="Paris",Food="Cheese",SightSeeing="Eiffel Tower"},
                new Destination{Country="Japan",City="Tokyo",Food="Sushi",SightSeeing="Skytree"},
                new Destination{Country="New Zealand",City="Nelson",Food="Wine",SightSeeing="Marlborough"},
                new Destination{Country="UK",City="London",Food="Fish & Chips.",SightSeeing="Wembley Stadium"}
            };
            foreach (Destination destination in destinations)
            {
                context.Destinations.Add(destination);
            }
            context.SaveChanges();
        }
    }
}
