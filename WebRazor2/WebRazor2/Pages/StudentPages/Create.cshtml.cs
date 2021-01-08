using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor2.Models;

namespace WebRazor2.Pages.StudentPages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public Student Student { get; set; }
        public CreateModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            await _context.Students.AddAsync(Student);
            await _context.SaveChangesAsync();
            return RedirectToPage("/StudentPages/Index");
        }
    }
}
