using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllAsync();
        Task<ProductModel> FindByIdAsync(long id);
        Task<ProductModel> CreateAsync(ProductModel product);
        Task<ProductModel> UpdateAsync(ProductModel product);
        Task<bool> DeleteAsync(long id);
    }
}
