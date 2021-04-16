using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using testwebapp.Models;
using testwebapp.Services;

namespace testwebapp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductsService productsService;

        [BindProperty]
        public Product Product { get; set; }

        public CreateModel(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await productsService.CreateAsync(Product);
            if (!result.IsSuccess)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
