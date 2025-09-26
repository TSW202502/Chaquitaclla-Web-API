using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Application.CommandServices;

public class SowingCommandService(ISowingRepository sowingRepository, IUnitOfWork unitOfWork)
: ISowingCommandService
{

    public async Task<Sowing> Handle(CreateSowingCommand command)
    {
        var sowing = new Sowing(command);
        try
        {
            await sowingRepository.AddAsync(sowing);
            await unitOfWork.CompleteAsync();
            return sowing;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new sowing", e);
        }
    }
    public async Task<Sowing> Handle(int id, UpdateSowingCommand command)
    {
        var sowing = await sowingRepository.FindByIdAsync(id);
        if (sowing == null)
        {
            throw new Exception("Sowing not found");
        }

        sowing.Update(command.AreaLand, command.CropId);

        try
        {
            await sowingRepository.UpdateAsync(sowing);
            await unitOfWork.CompleteAsync();
            return sowing;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to update the sowing", e);
        }
    }
}