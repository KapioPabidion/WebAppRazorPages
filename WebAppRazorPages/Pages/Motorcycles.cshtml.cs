using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Repository;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class MotorcyclesModel : PageModel
    {
        public MotorcyclesModel(IMotorcycle motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        private IMotorcycle _motorcycleRepository;
        public List<Motorcycle> Motorcycles { get; set; }
        public IActionResult OnGet()
        {
            Motorcycles = _motorcycleRepository.GetAll();
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            _motorcycleRepository.DeleteMotorcycle(id);
            return RedirectToPage();
        }
    }
}
