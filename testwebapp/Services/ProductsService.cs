using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using testwebapp.Models;

namespace testwebapp.Services
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient httpClient;

        public ProductsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<(bool IsSuccess, IEnumerable<Product> Results, string ErrorMessage)> GetAllAsync()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/products");
            if(result != null)
            {
                return (true, result, null);
            }
            return (false, null, "Error");
        }

        public async Task<(bool IsSuccess, Product Result, string ErrorMessage)> GetAsync(int id)
        {
            var result = await httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
            if (result != null)
            {
                return (true, result, null);
            }
            return (false, null, "Error");
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> CreateAsync(Product product)
        {
            var result = await httpClient.PostAsJsonAsync("api/products", product);
            if (result.IsSuccessStatusCode)
            {
                return (true, null);
            }
            return (false, result.ReasonPhrase);
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> UpdateAsync(int id, Product product)
        {
            var result = await httpClient.PutAsJsonAsync($"api/products/{id}", product);
            if (result.IsSuccessStatusCode)
            {
                return (true, null);
            }
            return (false, result.ReasonPhrase);
        }
    }
}