using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Transform;

public class ProductBySowingResourceFromEntityAssembler
{
    public static ProductBySowingResource ToResourceFromEntity(ProductsBySowing entity)
    {
        return new ProductBySowingResource( entity.UseDate, entity.Quantity);
    }
}
