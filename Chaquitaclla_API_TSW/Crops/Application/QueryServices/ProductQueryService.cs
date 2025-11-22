using Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;
using Chaquitaclla_API_TSW.Crops.Domain.Model.Queries;
using Chaquitaclla_API_TSW.Crops.Domain.Repositories;
using Chaquitaclla_API_TSW.Crops.Domain.Services;

namespace Chaquitaclla_API_TSW.Crops.Application.QueryServices;

public class ProductQueryService(IProductRepository productRepository ): IProductQueryService
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
    {
        return await productRepository.ListAsync();

    }

    public async Task<IEnumerable<Product>> Handle(GetProductsByTypeQuery query)
    {
        return await productRepository.FindByTypeAsync(query.Type);
    }

    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }
}
