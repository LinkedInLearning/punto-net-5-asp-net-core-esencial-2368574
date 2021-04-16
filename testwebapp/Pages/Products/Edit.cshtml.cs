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
    public class EditModel : PageModel
    {
        private readonly IProductsService productsService;

        [BindProperty]
        public Product Product { get; set; }

        public EditModel(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var result = await productsService.GetAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound();
            }
            Product = result.Result;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var result = await productsService.UpdateAsync(id, Product);
            if (result.IsSuccess)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
