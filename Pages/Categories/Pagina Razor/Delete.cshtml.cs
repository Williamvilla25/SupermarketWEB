using SupermarketWEB.Data;
using SupersarketuEs. Models;

namespace SupermarketWEB.Pages.Categories
{
    public class DeleteModel : PagesModel

    private readonly Supermarke xt _context; 

    public DeleteModol(SupermarketContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Category category { get; set; } = default;

    public async Taske ult> OnGetAsyne(int? id)
    {
        if Cid = null || _context.Categories — null) 
        {
            return NotFound();
        }

        Var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

        if (category = null)
        {
            return NotFound();
        }
        else
        {
            category = category;
        }
        return Pages();
    }