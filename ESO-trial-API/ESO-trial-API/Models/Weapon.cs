using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESO_trial_API.Models
{
    public class Weapon:Item
    {
        [Required]
        [Range(0, Int32.MaxValue)]
        public int damage { get; set; }
        [Required]
        [Range(0, Int32.MaxValue)]
        public int charge { get; set; }


    }
}
