using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRazor2;
using WebRazor2.Models;

namespace WebRazor2.Pages.StudentPages
{
    public class IndexModel : PageModel
    {
        private readonly WebRazor2.AppDbContext _context;

        public IndexModel(WebRazor2.AppDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
