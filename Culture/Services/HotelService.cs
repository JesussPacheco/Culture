using System;
using System.Threading.Tasks;
using Culture.Domain.Models;
using Culture.Domain.Repositories;
using Culture.Domain.Services;
using Culture.Domain.Services.Communication;

namespace Culture.Services
{
    
    public class HotelService:IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDestinationRepository _destinationRepository;

        public HotelService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork, IDestinationRepository destinationRepository)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
            _destinationRepository = destinationRepository;
        }

        public async Task<HotelResponse> FindByIdAsync(int id)
        {
            var existingHotel = await _hotelRepository.FindByIdAsync(id);
            if (existingHotel == null)
                return new HotelResponse(message: "Hotel not found");
            return new HotelResponse(existingHotel);
        }

        public async Task<HotelResponse> SaveAsync(Hotel hotel)
        {
            //validate DestinationId
            var existingDestination = _destinationRepository.FindByIdAsync(hotel.DestinationId);
            if (existingDestination == null)
                return new HotelResponse("Invalid Destination");
            
            try
            {
                await _hotelRepository.AddAsync(hotel);
                await _unitOfWork.CompleteAsync();
                return new HotelResponse(hotel);
            }
            catch (Exception e)
            {
                return new HotelResponse($"An occurred error: {e.Message}");
            }
        }

        public async Task<HotelResponse> UpdateAsync(int id, Hotel hotel)
        {
            var existingHotel = await _hotelRepository.FindByIdAsync(id);
            if (existingHotel == null)
                return new HotelResponse("Hotel not found");
            var existingDestination = _destinationRepository.FindByIdAsync(hotel.DestinationId);
            if (existingDestination == null)
                return new HotelResponse("Invalid Destination");

            existingHotel.Name = hotel.Name;
            existingHotel.Address= hotel.Address;
            existingHotel.Latitude = hotel.Latitude;
            existingHotel.Longitude = hotel.Longitude;

            try
            {
                _hotelRepository.Update(existingHotel);
                await _unitOfWork.CompleteAsync();
                return new HotelResponse(existingHotel);
            }
            catch (Exception e)
            {
                return new HotelResponse($"An occurred another error:{e.Message}");
            }
        }
    }
}