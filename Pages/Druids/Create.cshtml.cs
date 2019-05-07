using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DruidShapeshifting.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public SelectList pickCreature {get; set;}
        public List<Creature> Creatures {get; set;}

        [BindProperty]
        public int creatureid {get; set;}
        [BindProperty]
        public int druidid {get; set;}

        public IActionResult OnGet(int? id)
        {
            // Get a list of all the cretures names
            pickCreature = new SelectList(_context.Creature.OrderBy(c => c.Name).ToList(), "CreatureId", "Name", id);
            
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