using System.ComponentModel.DataAnnotations;

namespace Culture.Resources
{
    public class SaveDestinationResource
    {
        [Required]
        public  string Name { get; set; }
        [Required]
        public string  City { get; set; }
        [Required]
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }
}