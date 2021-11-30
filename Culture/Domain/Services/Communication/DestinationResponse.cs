using Culture.Domain.Models;

namespace Culture.Domain.Services.Communication
{
    public class DestinationResponse:BaseResponse<Destination>

    {
        public DestinationResponse(string message) : base(message)
        {
        }

        public DestinationResponse(Destination destination) : base(destination)
        {
        }
    }
}