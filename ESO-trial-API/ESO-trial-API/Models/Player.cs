using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESO_trial_API.Models
{
    public class Player
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string characterName { get; set; }
        [Required]
        [Range(1,50)]
        public int level { get; set; }
        [Required]
        [Range(0, 810)]
        public int cp { get; set; }
        [JsonIgnore]
        public ICollection<PlayerItem> playeritems { get; set; }
    }
}
