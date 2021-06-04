using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ESO_trial_API.Models
{
    public class Armor:Item
    {
        [Required]
        [Range(0, Int32.MaxValue)]
        public int armorRating { get; set; }
        [Required]
        [Range(0, Int32.MaxValue)]
        public int durability { get; set; }
        [Required]     
        public string armortype { get; set; }

    }
}
