using Juan.Areas.Admin.Models;
using Juan.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Juan.Areas.Admin.Controllers
{
[Area(nameof(Admin))]
    public class SliderController : Controller
    {
        private readonly JuanDbContext _context;

        public SliderController(JuanDbContext context)
        {
            _context = context;
        }

         public async Task<IActionResult> Index()
        {
            var slider = await _context.Sliders.ToListAsync();
           

            return View(slider);
        }
        public async Task<IActionResult>Detail(int id)
        {
            var slider = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(s=>s.Id==id);
            if(slider == null)  
                return NotFound();
            return View(slider);
        }
        public async Task<IActionResult>Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(Slider slider)
        {

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Update(int id)
        {
            var slider = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(s=>s.Id==id);
            if(slider == null) 
            return NotFound();
            return View(slider);
        }
        [HttpPost]
        public async Task<IActionResult>Update(int id, Slider slider)
        {
            var dbSlider = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id==id);
            if(slider == null)
                return NotFound();
            
            dbSlider.Title = slider.Title;
            dbSlider.Description = slider.Description;
            dbSlider.SubTitle = slider.SubTitle;
            dbSlider.Image  = slider.Image;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult>Delete(int id)
        {
            var slider = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(s=>s.Id==id);
            if(slider == null)
                return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteSlider(int id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
                if (slider == null) 
                return NotFound();

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
