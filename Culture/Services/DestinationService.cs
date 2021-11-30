using System;
using System.Threading.Tasks;
using Culture.Domain.Models;
using Culture.Domain.Repositories;
using Culture.Domain.Services;
using Culture.Domain.Services.Communication;

namespace Culture.Services
{
    public class DestinationService:IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DestinationService(IDestinationRepository destinationRepository, IUnitOfWork unitOfWork)
        {
            _destinationRepository = destinationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DestinationResponse> SaveAsync(Destination destination)
        {
            try
            {
                await _destinationRepository.AddAsync(destination);
                await _unitOfWork.CompleteAsync();
                return new DestinationResponse(destination);
            }
            catch (Exception e)
            {
                return new DestinationResponse($"An error occurred while add destination:{e.Message}");
            }
        }

        public async Task<DestinationResponse> FindByIdAsync(int id)
        {
            var existingDestination = await _destinationRepository.FindByIdAsync(id);
            if (existingDestination == null)
                return new DestinationResponse(message: "Destination not found");
            return new DestinationResponse(existingDestination);
        }
    }
}