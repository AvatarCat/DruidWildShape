using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DruidShapeshifting.Models;

namespace DruidShapeshifting.Pages_Creatures
{
    public class EditModel : PageModel
    {
        private readonly DruidShapeshifting.Models.DruidShapeshiftingContext _context;

        public EditModel(DruidShapeshifting.Models.DruidShapeshiftingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Creature Creature { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Creature = await _context.Creature.FirstOrDefaultAsync(m => m.CreatureId == id);

            if (Creature == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Creature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreatureExists(Creature.CreatureId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CreatureExists(int id)
        {
            return _context.Creature.Any(e => e.CreatureId == id);
        }
    }
}
