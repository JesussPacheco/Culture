using System.Collections;
using System.Threading.Tasks;
using AutoMapper;
using Culture.Domain.Models;
using Culture.Domain.Services;
using Culture.Extensions;
using Culture.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Culture.Controllers
{
    [Route("/api/v1/[controller]")]
    public class DestinationController:ControllerBase
    {
        private readonly IDestinationService  _destinationService;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDestinationResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var destination = _mapper.Map<SaveDestinationResource, Destination>(resource);
            var result = await _destinationService.SaveAsync(destination);
            if (!result.Success)
                return BadRequest(result.Message);
            var destinationResource = _mapper.Map<Destination, DestinationResource>(result.Resource);
            return Ok(destinationResource);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromBody] SaveDestinationResource resource)
        {
            var result = await _destinationService.FindByIdAsync(id);
            var destinationResource = _mapper.Map<Destination, DestinationResource>(result.Resource);
            return Ok(destinationResource);
        }
        


    }
}