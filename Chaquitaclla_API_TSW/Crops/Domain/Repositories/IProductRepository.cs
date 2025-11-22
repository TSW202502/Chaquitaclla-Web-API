using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.ValueObjects;
using Chaquitaclla_API_TSW.Shared.Domain.Repositories;

namespace Chaquitaclla_API_TSW.Crops.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    /**
     * Method of the interface that allows to search for a product by its type
     */
    Task<IEnumerable<Product>> FindByTypeAsync(EProductType type);
    
}
