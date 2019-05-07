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

namespace DruidShapeshifting.Pages_Creatures
{
    public class IndexModel : PageModel
    {
        private readonly DruidShapeshifting.Models.DruidShapeshiftingContext _context;

        public IndexModel(DruidShapeshifting.Models.DruidShapeshiftingContext context)
        {
            _context = context;
        }

        public IList<Creature> Creature { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString {get; set;}

        public SelectList challengeRating {get; set;}

        [BindProperty(SupportsGet = true)]
        public string CreatureChallenge {get; set;}

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;
        public int numOfPages {get; set;} = 0;


        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}

        public string upArrow {get; set;}
        public string downArrow {get; set;}
        public string sideArrow {get; set;}

        public async Task OnGetAsync()
        {
            // Gets the creatures
            var query = _context.Creature.Select(c => c);

            var CR = from c in _context.Creature
                    orderby c.Challenge
                    select c.Challenge;

            // Switch statement to select how the Name and Challenge are being ordered by
            switch(CurrentSort)
            {
                case "nameAsc":
                    query = query.OrderBy(n => n.Name);
                    break;
                case "nameDesc":
                    query = query.OrderByDescending(n => n.Name);
                    break;
                case "challengeAsc":
                    query = query.OrderBy(c => c.Challenge);
                    break;
                case "challengeDesc":
                    query = query.OrderByDescending(c => c.Challenge);
                    break;
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(CreatureChallenge))
            {
                query = query.Where(x => x.Challenge == CreatureChallenge);
            }

            // Get the number of Creatures by counting the names
            var numofCreatures = _context.Creature.Select(n => n.Name).Count();

            // Get the number of pages by dividing the number of Creatures by the page size and round up
            // ex. 103 creatures/15 creatures per page = 6.867, rounds up to 7 pages
            numOfPages = (int)Math.Ceiling(Convert.ToDecimal(numofCreatures)/PageSize);

            // Create a list of Challenge Ratings
            challengeRating = new SelectList(await CR.Distinct().ToListAsync());

            // List all the creatures
            Creature = query.Skip((PageNum - 1)*PageSize).Take(PageSize).ToList();

            upArrow = "⯅";
            downArrow = "⯆";
            sideArrow = "⯈";
        }
    }
}