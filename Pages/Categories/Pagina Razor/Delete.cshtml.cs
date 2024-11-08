using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;

        [BindProperty]
        public Product Product { get; set; }

        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>
    OnGetAsync(int? id)
    {
    if (id == null) return NotFound();

    Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

    if (Product == null) return NotFound();

    return Page();
    }

    public async Task<IActionResult>
        OnPostAsync(int? id)
        {
        if (id == null) return NotFound();

        Product = await _context.Products.FindAsync(id);

        if (Product != null)
        {
        _context.Products.Remove(Product);
        await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
        }
        }
        }
