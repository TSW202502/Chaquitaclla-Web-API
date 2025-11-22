using Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Forum.Domain.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    bool ExistsByCategoryName(string name);
}
