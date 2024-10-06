using Juan.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Juan.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Shipping> Shippings { get; set; }
    }
}
