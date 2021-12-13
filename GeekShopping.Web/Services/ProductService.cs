using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string BASE_PATH = "api/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductModel>> FindAllAsync()
        {
            var response = await _httpClient.GetAsync(BASE_PATH);
            return await response.ReadContentAsAsync<List<ProductModel>>();
        }

        public async Task<ProductModel> FindByIdAsync(long id)
        {
            var response = await _httpClient.GetAsync($"{BASE_PATH}/{id}");
            return await response.ReadContentAsAsync<ProductModel>();
        }

        public async Task<ProductModel> CreateAsync(ProductModel product)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_PATH, product);
            
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsAsync<ProductModel>();
            else
                throw new Exception($"Algo deu errado ao chamar api: {response.ReasonPhrase}");
        }

        public async Task<ProductModel> UpdateAsync(ProductModel product)
        {
            var response = await _httpClient.PutAsJsonAsync(BASE_PATH, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsAsync<ProductModel>();
            else
                throw new Exception($"Algo deu errado ao chamar api: {response.ReasonPhrase}");
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_PATH}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsAsync<bool>();
            else
                throw new Exception($"Algo deu errado ao chamar api: {response.ReasonPhrase}");
        }

    }
}
