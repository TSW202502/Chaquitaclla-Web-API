using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Application.CommandServices;

public class PestCommandService(IPestRepository pestRepository, IUnitOfWork unitOfWork)
    : IPestCommandService
{
    public async Task<Pest> Handle(CreatePestCommand command)
    {
        var pest = new Pest
        {
            Name = command.Name,
            Description = command.Description,
            Solution = command.Solution,
        };
        
        try
        {
            await pestRepository.AddAsync(pest);
            await unitOfWork.CompleteAsync();
            return pest;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Pest", e);
        }
    }
}