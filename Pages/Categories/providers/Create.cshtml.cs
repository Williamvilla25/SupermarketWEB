using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{
	public class CreateModel : PageModel
	{
		private readonly SupermarketContext _context;

		[BindProperty]
		public Provider Provider { get; set; }

		public CreateModel(SupermarketContext context)
		{
			_context = context;
		}

		public IActionResult OnGet() => Page();

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid) return Page();

			_context.Providers.Add(Provider);
			await _context.SaveChangesAsync();
			return RedirectToPage("./Index");
		}
	}
}
