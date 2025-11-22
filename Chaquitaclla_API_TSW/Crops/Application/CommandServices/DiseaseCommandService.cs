using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Chaquitaclla_API_TSW.Crops.Application.CommandServices
{
    public class DiseaseCommandService(IDiseaseRepository diseaseRepository, IUnitOfWork unitOfWork) : IDiseaseCommandService
    {
      public async Task<Disease> Handle(CreateDiseaseCommand command)
        {
            var disease = new Disease
            {
                Name = command.Name,
                Description = command.Description,
                Solution = command.Solution,
            };

            try
            {
                await diseaseRepository.AddAsync(disease);
                await unitOfWork.CompleteAsync();
                return disease;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while trying to add the new Disease", e);
            }
        }
    }
}
