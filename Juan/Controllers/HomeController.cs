using Juan.Areas.Admin.Models;
using Juan.Contexts;
using Juan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Juan.Controllers;

public class HomeController : Controller
{
    private readonly JuanDbContext _context;

    public HomeController(JuanDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var sliders =await _context.Sliders.ToListAsync();
        var shippings =await _context.Shippings.ToListAsync();

        HomeViewModel homeViewModel = new HomeViewModel()
        {
            Sliders = sliders,
            Shippings = shippings

        };
        return View(homeViewModel);
    }
}
