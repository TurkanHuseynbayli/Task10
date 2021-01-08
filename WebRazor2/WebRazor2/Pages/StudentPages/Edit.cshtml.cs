using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor2.Models;

namespace WebRazor2.Pages.StudentPages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public Student Student { get; set; }
        public EditModel(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student = _context.Students.FirstOrDefault(s=>s.Id==id);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(int? id)
        {
            if (!ModelState.IsValid) return Page();
            if (id == null)
            {
                return NotFound();
            }
            Student dbStudent = _context.Students.Find(id);
            if (dbStudent == null)
            {
                return NotFound();
            }
            dbStudent.Name = Student.Name;
            dbStudent.SurName = Student.SurName;
            await _context.SaveChangesAsync();
            return RedirectToPage("/StudentPages/Index");
        }

    }

}
