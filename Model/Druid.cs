using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DruidShapeshifting.Models
{
    public class Druid
    {
        public int DruidId { get; set;}

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(25), Required]
        public string Name { get; set;}

        [Range(1, 20), Required]
        public int Level {get; set;}

        [StringLength(60), Required]
        public string Race { get; set;}
        public List<Creature> Creatures {get; set;}
    }
}