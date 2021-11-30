using Culture.Domain.Models;

namespace Culture.Domain.Services.Communication
{
    public class HotelResponse:BaseResponse<Hotel>
    {
        public HotelResponse(string message) : base(message)
        {
        }

        public HotelResponse(Hotel resource) : base(resource)
        {
        }
    }
}