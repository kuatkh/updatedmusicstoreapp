using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}