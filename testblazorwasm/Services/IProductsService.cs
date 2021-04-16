using System.Collections.Generic;
using System.Threading.Tasks;
using testblazorwasm.Models;

namespace testblazorwasm.Services
{
    public interface IProductsService
    {
        Task<(bool IsSuccess, IEnumerable<Product> Results, string ErrorMessage)> GetAllAsync();
        Task<(bool IsSuccess, Product Result, string ErrorMessage)> GetAsync(int id);
        Task<(bool IsSuccess, string ErrorMessage)> CreateAsync(Product product);
        Task<(bool IsSuccess, string ErrorMessage)> UpdateAsync(int id, Product product);
    }
}