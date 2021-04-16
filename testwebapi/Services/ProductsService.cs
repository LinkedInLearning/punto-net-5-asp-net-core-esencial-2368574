using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testwebapi.Models;

namespace testwebapi.Services
{
    public class ProductsService : IProductsService
    {
        private readonly List<Product> products;
        public ProductsService()
        {
            products = new List<Product>
            {
                new Product() { Id = 1, Name = "Monitor", Price = 350, InStock = true },
                new Product() { Id = 2, Name = "Teclado", Price = 28, InStock = false },
                new Product() { Id = 3, Name = "Mouse", Price = 20, InStock = true }
            };
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> CreateAsync(Product product)
        {
            var newId = products.Max(p => p.Id) + 1;
            product.Id = newId;
            products.Add(product);
            await Task.Delay(1);
            return (true, null);
        }

        public async Task<(bool IsSuccess, IEnumerable<Product> Results, string ErrorMessage)> GetAllAsync()
        {
            await Task.Delay(1);
            return (true, products, null);
        }

        public async Task<(bool IsSuccess, Product Result, string ErrorMessage)> GetAsync(int id)
        {
            await Task.Delay(1);
            var result = products.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                return (true, result, null);
            }
            return (false, null, "Not found");
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> UpdateAsync(int id, Product product)
        {
            await Task.Delay(1);
            var productToUpdate = products.FirstOrDefault(p => p.Id == id);
            if (productToUpdate == null)
            {
                return (false, "Not found");
            }
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.InStock = product.InStock;

            return (true, null);
        }
    }
}