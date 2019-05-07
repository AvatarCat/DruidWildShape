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
    public class CreatureModel : PageModel
    {
        private readonly DruidShapeshifting.Models.DruidShapeshiftingContext _context;

        public CreatureModel(DruidShapeshifting.Models.DruidShapeshiftingContext context)
        {
            _context = context;
        }

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

        public string message {get; set;}

        public IActionResult OnGet(int? id)
        {
            // Get a list of all the cretures names
            pickCreature = new SelectList(_context.Creature.OrderBy(c => c.Name).ToList(), "CreatureId", "Name", id);

            // Get the DruidId
            Druid = _context.Druid.Include(d => d.Creatures).Where(d => d.DruidId == id).FirstOrDefault();

            // set druidid to getDruid
            druidid = Druid.DruidId;

            // Create a message to diplay above the select list
            message = "Add creature"; 

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

    
                Druid.Creatures.Add(getCreature);
                _context.SaveChanges();
            
            // Return to the Creature page after adding the creature to the list
            return RedirectToPage("/Druids/Creature", new { id = druidid });
        }

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
    }
}