using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Application.CommandServices;

public class CropCommandService : ICropCommandService
{
    private readonly ICropRepository cropRepository;
    private readonly IUnitOfWork unitOfWork;

    public CropCommandService(ICropRepository cropRepository, IUnitOfWork unitOfWork)
    {
        this.cropRepository = cropRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Crop> Handle(CreateCropCommand command)
    {
        var crop = new Crop(command);
        try
        {
            await cropRepository.AddAsync(crop);
            await unitOfWork.CompleteAsync();
            return crop;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Crop", e);
        }
    }

    public async Task<Crop> Handle(int id, UpdateCropCommand command)
    {
        var crop = await cropRepository.FindByIdAsync(id);
        if (crop == null)
        {
            throw new Exception("Crop not found");
        }

        crop.Update(command.Name, command.Description); // Assuming Update method exists in Crop class

        try
        {
            await cropRepository.UpdateAsync(crop);
            await unitOfWork.CompleteAsync();
            return crop;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to update the Crop", e);
        }
    }
}