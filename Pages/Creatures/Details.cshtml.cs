using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DruidShapeshifting.Models;

namespace DruidShapeshifting.Pages_Creatures
{
    public class DetailsModel : PageModel
    {
        private readonly DruidShapeshifting.Models.DruidShapeshiftingContext _context;

        public DetailsModel(DruidShapeshifting.Models.DruidShapeshiftingContext context)
        {
            _context = context;
        }

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
    }
}
