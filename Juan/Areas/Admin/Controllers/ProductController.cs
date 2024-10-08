using Juan.Areas.Admin.Models;
using Juan.Areas.Admin.ViewModels.ProductViewModels;
using Juan.Contexts;
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
        var product = await _context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Where(p=>!p.IsDeleted)
            .ToListAsync();

        return View(product);
    }
    public async Task<IActionResult>Create()
    {
       ViewBag.Categories = await _context.Categories.ToListAsync();
       return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult>Create(ProductCreateViewModel product)
    {
        Product newProduct = new()
        {
            Name = product.Name,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Price = product.Price,
            Image = product.Image,
            Rating = product.Rating,
            CreatedTime = DateTime.UtcNow

        };
        await _context.AddAsync(newProduct);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));

    }
    public async Task<IActionResult>Update(int id)
    {
        var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p=>p.Id==id & !p.IsDeleted);
        if(product == null)
            return NotFound();

        ProductUpdateViewModel productUpdateViewModel = new()
        {
            Name = product.Name,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Price = product.Price,
            Image = product.Image,
            Rating = product.Rating,
            UpdatedTime = DateTime.UtcNow

        };

        ViewBag.Categories = await _context.Categories.ToListAsync();

        return View(productUpdateViewModel);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult>Update(int id, ProductUpdateViewModel productUpdateViewModel)
    {
        var product  = await _context.Products.FirstOrDefaultAsync(p=>p.Id== id);
        if(product == null)
            return NotFound();

        product.Name = productUpdateViewModel.Name;
        product.Description = productUpdateViewModel.Description;
        product.Image = productUpdateViewModel.Image;
        product.Rating = productUpdateViewModel.Rating;
        product.UpdatedTime = DateTime.UtcNow;
        product.DiscountPercent= productUpdateViewModel.DiscountPercent;
        product.Price = productUpdateViewModel.Price;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult>Delete(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p=>p.Id== id & !p.IsDeleted);
        if(product == null) return NotFound();

        return View(product);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult>DeleteProduct(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p=>p.Id==id & !p.IsDeleted);
        if(product == null) return NotFound();

        _context.Products.Remove(product);  
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


}
