using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ESO_trial_API.Models
{
    public class PlayerItem
    {
        public int itemid { get; set; }
        public Item item { get; set; }
        public int playerid { get; set; }
        public Player player { get; set; }
    }
}
