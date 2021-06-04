using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ESO_trial_API.Models
{
    public class Rarity
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [JsonIgnore]
        public ICollection<Item> items { get; set; }
    }
}
