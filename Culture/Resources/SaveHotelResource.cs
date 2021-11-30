using System.ComponentModel.DataAnnotations;

namespace Culture.Resources
{
    public class SaveHotelResource
    {
        [Required]
        public  string Name { get; set; }
        [Required]
        public string Address     {get; set; }

        public string PhotoUrl { get; set; }
        
        [Required]
        public double Altitude { get; set; }
        
        [Required]
        public double Latitude { get; set; }
        [Required]
        public  double Longitude { get; set; }

    }
}