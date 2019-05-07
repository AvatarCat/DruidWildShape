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
         public Druid Druid {get; set;}
        public Creature Creature {get; set;}

        public SelectList pickCreature {get; set;}
        public List<Creature> Creatures {get; set;}

        [BindProperty]
        public int creatureid {get; set;}
        [BindProperty]
        public int druidid {get; set;}
        [BindProperty]
        public int CreatureToDelete {get; set;}


        public IActionResult OnGet(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Get a list of all the cretures names
            pickCreature = new SelectList(_context.Creature.OrderBy(c => c.Name).ToList(), "CreatureId", "Name", id);

            // Get the Druid
            Druid = _context.Druid.Include(d => d.Creatures).Where(d => d.DruidId == id).FirstOrDefault();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Get the Druid
            Druid = _context.Druid.Include(d => d.Creatures).Where(d => d.DruidId == druidid).FirstOrDefault();

            //Get the Creature
            var getCreature = _context.Creature.Where(c => c.CreatureId == creatureid).Select(c => c).FirstOrDefault();
            // Get the CreatureId
            var getCreatureId = getCreature.CreatureId;  //var getCreatureId = _context.Creature.Where(c => c.CreatureId == creatureid).Select(c => c.CreatureId).FirstOrDefault();

            // Get creature id
            Creature = await _context.Creature.FirstOrDefaultAsync(m => m.CreatureId == id);
            // List all the creatures
            Creatures = await _context.Creature.ToListAsync();
            
            if (Creature == null)
            {
                return NotFound();
            }

            _context.Druid.Add(Druid);
            Druid.Creatures.Add(getCreature);
            await _context.SaveChangesAsync();
            
            // Return to the Creature page after adding the creature to the list
            return RedirectToPage("./Index");
        }

        /*
        public IActionResult OnPostDeleteCreature(int? id)
        {
            //Druid = _context.Druid.Include(d => d.Creatures).Where(d => d.DruidId == id).FirstOrDefault();

            Creature Creature = _context.Creature.FirstOrDefault(c => c.CreatureId == CreatureToDelete);

            if (Creature != null)
            {
                _context.Creature.Remove(Creature);
                _context.SaveChanges();
            }

            return RedirectToPage("/Druids/Creature", new { id = druidid });
        }
        */
    }
}