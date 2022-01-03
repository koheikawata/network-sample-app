using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TravelApiSql.Models
{
    public class Destination
    {
        [Key]
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Food { get; set; }
        public string? SightSeeing { get; set; }
    }
}
