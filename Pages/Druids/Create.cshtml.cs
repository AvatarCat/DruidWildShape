using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DruidShapeshifting.Models;

namespace DruidShapeshifting.Pages_Druid
{
    public class CreateModel : PageModel
    {
        private readonly DruidShapeshifting.Models.DruidShapeshiftingContext _context;

        public CreateModel(DruidShapeshifting.Models.DruidShapeshiftingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Druid Druid { get; set; }
        

        public IActionResult OnGet(int? id)
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Druid.Add(Druid);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}