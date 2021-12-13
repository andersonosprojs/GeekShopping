using GeekShopping.Product.API.Data.ValueObjects;

namespace GeekShopping.Product.API.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAllAsync();
        Task<ProductVO> FindByIdAsync(long id);
        Task<ProductVO> CreateAsync(ProductVO productVO);
        Task<ProductVO> UpdateAsync(ProductVO productVO);
        Task<bool> DeleteAsync(long id);
    }
}
