using Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Application.CommandServices;

public class CareCommandService(ICareRepository careRepository, IUnitOfWork unitOfWork) : ICareCommandService
{
    public async Task<Care> Handle(CreateCareCommand command)
    {
        var care = new Care
        {
            Suggestion = command.suggestion,
            Date = command.date,
        };

        try
        {
            await careRepository.AddAsync(care);
            await unitOfWork.CompleteAsync();
            return care;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Care", e);
        }
    }
}
