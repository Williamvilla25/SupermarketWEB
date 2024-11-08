using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{
    public class EditModel : PageModel
    {
        private readonly SupermarketContext _context;

        [BindProperty]
        public Provider Provider { get; set; }

        public EditModel(SupermarketContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Provider = await _context.Providers.FindAsync(id);

            if (Provider == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Provider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(Provider.Id)) return NotFound();
                else throw;
            }

            return RedirectToPage("./Index");
        }

        private bool ProviderExists(int id)
        {
            return _context.Providers.Any(e => e.Id == id);
        }
    }
}
