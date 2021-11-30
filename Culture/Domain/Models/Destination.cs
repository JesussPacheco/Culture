using System.Collections;
using System.Collections.Generic;

namespace Culture.Domain.Models
{
    public class Destination
    {
        public int  Id { get; set; }
        public  string Name { get; set; }
        public string  City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        
        public IList<Hotel>Hotels { get; set; }
    }
}