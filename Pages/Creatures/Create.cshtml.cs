using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DruidShapeshifting.Models;

namespace DruidShapeshifting.Pages_Creatures
{
    public class CreateModel : PageModel
    {
        private readonly DruidShapeshifting.Models.DruidShapeshiftingContext _context;

        public CreateModel(DruidShapeshifting.Models.DruidShapeshiftingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Creature Creature { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Creature.Add(Creature);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}