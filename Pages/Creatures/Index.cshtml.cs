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
        public int filterChallengeNum {get; set;}
        public int filterSearchNum {get; set;}
        public int fcPageNum {get; set;}
        public int fsPageNum {get; set;}


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

            // Get the number of Creatures by counting the names
            var numofCreatures = _context.Creature.Select(n => n.Name).Count();
            // Set FilterChallegeNum to equal numofCreatures
            filterChallengeNum = numofCreatures;
            // Set FilterSearchNum to equal numofCreatures
            filterSearchNum = numofCreatures;

            // if SearchString is not null or empty, find Names that contain SearchString
            // and make filterSearchNum equal the amount of results
            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(s => s.Name.Contains(SearchString));
                filterSearchNum = query.Count();
            }

            // if CreatureChallenge is not null or empty, find Names that contain CreatureChallenge
            // and make filterChallengeNum equal the amount of results
            if (!string.IsNullOrEmpty(CreatureChallenge))
            {
                query = query.Where(x => x.Challenge == CreatureChallenge);
                filterChallengeNum = query.Count();
            }

            // Get the number of pages by dividing the number of Creatures by the page size and round up
            // ex. 103 creatures/15 creatures per page = 6.867, rounds up to 7 pages
            numOfPages = (int)Math.Ceiling(Convert.ToDecimal(numofCreatures)/PageSize);

            fcPageNum = numOfPages;
            fsPageNum = numOfPages;

            // Get the number of pages by dividing the number of Creatures, when filtered by the Challenge Rating, by the page size and round up
            fcPageNum = (int)Math.Ceiling(Convert.ToDecimal(filterChallengeNum)/PageSize);
            // Get the number of pages by dividing the number of Creatures, when filtered by Search Bar, by the page size and round up
            fsPageNum = (int)Math.Ceiling(Convert.ToDecimal(filterSearchNum)/PageSize);

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
