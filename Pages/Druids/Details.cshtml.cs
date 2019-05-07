using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DruidShapeshifting.Models;

namespace DruidShapeshifting.Pages_Druid
{
    public class DetailsModel : PageModel
    {
        private readonly DruidShapeshifting.Models.DruidShapeshiftingContext _context;

        public DetailsModel(DruidShapeshifting.Models.DruidShapeshiftingContext context)
        {
            _context = context;
        }

        public Druid Druid { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Druid = await _context.Druid.FirstOrDefaultAsync(m => m.DruidId == id);

            if (Druid == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
