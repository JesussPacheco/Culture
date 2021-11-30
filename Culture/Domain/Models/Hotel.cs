namespace Culture.Domain.Models
{
    public class Hotel
    {
        public int Id             { get; set; }
        public  string Name { get; set; }
        public string Address     {get; set; }
        public string PhotoUrl { get; set; }
        public double Altitude { get; set; }
        public double Latitude { get; set; }
        public  double Longitude { get; set; }
        
        //Relation
        public  int DestinationId { get; set; }
        public Destination Destination { get; set; }
        
    }
}