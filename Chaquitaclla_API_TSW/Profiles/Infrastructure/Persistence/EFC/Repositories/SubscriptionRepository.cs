using Chaquitaclla_API_TSW.Profiles.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Profiles.Domain.Repositories;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Configuration;
using Chaquitaclla_API_TSW.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Chaquitaclla_API_TSW.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository(AppDbContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    
}
