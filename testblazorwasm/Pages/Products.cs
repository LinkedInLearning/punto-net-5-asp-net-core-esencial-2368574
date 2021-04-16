using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testblazorwasm.Models;
using testblazorwasm.Services;

namespace testblazorwasm.Pages
{
    public partial class Products
    {
        [Inject]
        public IProductsService ProductsService { get; set; }

        public List<Product> AllProducts { get; set; } = new List<Product>();
        
        public string FilterTerm { get; set; }

        public bool Filter(Product product)
        {
            if (string.IsNullOrEmpty(FilterTerm))
            {
                return true;
            }

            if (product.Name.Contains(FilterTerm, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
        protected override async Task OnInitializedAsync()
        {
            var result = await ProductsService.GetAllAsync();
            if (result.IsSuccess && result.Results != null && result.Results.Any())
            {
                AllProducts = new List<Product>(result.Results);
            }
        }
    }
}