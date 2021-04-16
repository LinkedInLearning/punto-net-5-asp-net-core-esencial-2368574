using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testwebapp.Models;
using testwebapp.Services;

namespace testwebapp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductsService productsService;

        public List<Product> Products { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        public async Task OnGetAsync()
        {
            var result = await productsService.GetAllAsync();
            if (result.Results != null && result.Results.Any())
            {
                Products = new List<Product>(result.Results);
                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    Products = Products.Where(p => p.Name.ToLowerInvariant().Contains(SearchTerm.ToLowerInvariant())).ToList();
                }
            }
            else
            {
                Products = new List<Product>();
            }
        }
    }
}
