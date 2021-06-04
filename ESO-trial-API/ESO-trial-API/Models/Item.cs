using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESO_trial_API.Models
{
    public class Item
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [Range(0, Int32.MaxValue)]
        public int value { get; set; }

        public int traitid { get; set; }
        public Trait trait { get; set; }

        public int rarityid { get; set; }
        public Rarity rarity { get; set; }

        public int setid { get; set; }
        public Set set { get; set; }

        public int enchantmentid { get; set; }
        public Enchantment enchantment { get; set; }

        [Required]
        public string item_type { get; set; }
        [JsonIgnore]
        public ICollection<PlayerItem> playeritems { get; set; }
    }
}
