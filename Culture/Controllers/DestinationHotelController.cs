using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Culture.Domain.Models;
using Culture.Domain.Services;
using Culture.Extensions;
using Culture.Resources;

namespace Culture.Controllers
{
    [ApiController]
    [Route("/api/v1/{destinationId}/[controller]")]
    public class DestinationHotelController:ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public DestinationHotelController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveHotelResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var hotel = _mapper.Map<SaveHotelResource, Hotel>(resource);

            var result = await _hotelService.SaveAsync(hotel);

            if (!result.Success)
                return BadRequest(result.Message);

            var hotelResource = _mapper.Map<Hotel, HotelResource>(result.Resource);

            return Ok(hotelResource);
        }
        //29-10
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveHotelResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var hotel = _mapper.Map<SaveHotelResource, Hotel>(resource);

            var result = await _hotelService.UpdateAsync(id, hotel);

            if (!result.Success)
                return BadRequest(result.Message);

            var hotelResource = _mapper.Map<Hotel, HotelResource>(result.Resource);

            return Ok(hotelResource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromBody] SaveHotelResource resource)
        {
            var result = await _hotelService.FindByIdAsync(id);
            var hotelResource = _mapper.Map<Hotel, HotelResource>(result.Resource);
            return Ok(hotelResource);
        }
    }
}