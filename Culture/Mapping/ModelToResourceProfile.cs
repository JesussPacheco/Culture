using AutoMapper;
using Culture.Domain.Models;
using Culture.Resources;

namespace Culture.Mapping
{
    
    public class ModelToResourceProfile:Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Destination, DestinationResource>();
  
        }
    }
}