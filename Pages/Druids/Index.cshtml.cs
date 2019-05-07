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
    public class IndexModel : PageModel
    {
        private readonly DruidShapeshifting.Models.DruidShapeshiftingContext _context;

        public IndexModel(DruidShapeshifting.Models.DruidShapeshiftingContext context)
        {
            _context = context;
        }

        public IList<Druid> Druid {get;set;}

        public async Task OnGetAsync(int? id)
        {
            var druids = _context.Druid.Include(d => d.Creatures).Select(d => d);

            Druid = await druids.ToListAsync();
        }
    }
}
