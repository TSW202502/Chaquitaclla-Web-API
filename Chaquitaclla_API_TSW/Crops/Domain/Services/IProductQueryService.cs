using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;

namespace Chaquitaclla_API_TSW.Crops.Domain.Services;

public interface IProductQueryService
{
    /**
     * Return all products
     */
    Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
    
    /**
     * Return products by type
     */
    Task<IEnumerable<Product>> Handle(GetProductsByTypeQuery query);
    
    /**
     * Return product by id
     */
    Task<Product?> Handle(GetProductByIdQuery query);
}