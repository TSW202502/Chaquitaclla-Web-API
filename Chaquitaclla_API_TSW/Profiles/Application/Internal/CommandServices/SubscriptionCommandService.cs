using Chaquitaclla_API_TSW.Profiles.Domain.Model.Commands;
using Chaquitaclla_API_TSW.Profiles.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Profiles.Domain.Repositories;
using Chaquitaclla_API_TSW.Profiles.Domain.Services;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Profiles.Application.Internal.CommandServices;

public class SubscriptionCommandService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork) : ISubscriptionCommandService
{
    public async Task<Subscription?> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command);
        try
        {
            await subscriptionRepository.AddAsync(subscription);
            await unitOfWork.CompleteAsync();
            return subscription;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}
