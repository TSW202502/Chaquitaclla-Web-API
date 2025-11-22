using Chaquitaclla_API_TSW.IAM.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.IAM.Domain.Model.Queries;

namespace Chaquitaclla_API_TSW.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}
