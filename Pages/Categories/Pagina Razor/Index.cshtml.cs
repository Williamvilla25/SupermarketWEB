using Microsoft.AspNetCore.Mvc.RazorPages;
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


        public IList<Category> Categories { get; set; } = new default!;

        public async Task OnGetAsync()
        {
            if (_context.Ctegries != null)
            {
                Categories = await _context.Categories.ToListAsync();
            }
        }
    }
}    
  