using System;
using System.ComponentModel.DataAnnotations;

namespace DruidShapeshifting.Models
{
    public class Creature
    {
        public int CreatureId { get; set;}

        [StringLength(60), Required]
        public string Name {get; set;}

        [StringLength(3), Required]
        public string Challenge {get; set;}

        [StringLength(15), Required]
        public string HitPoints {get; set;}

        [Range(1, 50), Required]
        public int Armor {get; set;}
        public int? DruidId {get; set;}
        public Druid Druid {get; set;}
    }
}