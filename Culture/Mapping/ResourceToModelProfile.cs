using AutoMapper;
using Culture.Domain.Models;
using Culture.Resources;

namespace Culture.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveDestinationResource, Destination>();
           
        }
    }
}