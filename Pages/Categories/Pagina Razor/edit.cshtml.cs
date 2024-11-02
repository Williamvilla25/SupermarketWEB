using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketwEB.Models;
using SupermarketEF.Models;

namespace SupermarketWEB.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContexte _context;

        public IndexModel(SupermarketContext context)
        {
            _context = contex;
        }

        [BindProperty]

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ctegries != null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            Category = category;
            return Pages();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Pages();
            }

            _context.Attach(Category).State = EntityState.Modified;
            E
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Category.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(equals => equals.Id == id)).GetValueOrDefault();
        }
     }
  }