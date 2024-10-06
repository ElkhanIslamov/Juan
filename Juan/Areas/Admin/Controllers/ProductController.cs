using Juan.Contexts;
using Juan.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Juan.Areas.Admin.Controllers;
[Area(nameof(Admin))]
public class ProductController : Controller
{
    private readonly JuanDbContext _context;

    public ProductController(JuanDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var product = await _context.Products.AsNoTracking().ToListAsync();
        return View(product);
    }
    public async Task<IActionResult>Create()
    {
        ViewBag.Categories = await _context.Categories.AsNoTracking().ToListAsync();
       return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult>Create(ProductCreateViewModel productCreateViewModel)
    {
       
        await _context.AddAsync(productCreateViewModel);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));

    }
}
