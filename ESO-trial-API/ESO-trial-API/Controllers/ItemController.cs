using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESO_trial_API.Models;
using ESO_trial_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ESO_trial_API.Controllers
{
    [Authorize]
    [Route("api/v1/items")]
    public class itemController : Controller
    {
        private readonly ESOTrialContext context;
        public itemController(ESOTrialContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Item> GetAllItems()
        {
            return context.Items
                .Include(r => r.rarity)
                .Include(e => e.enchantment)
                .Include(s => s.set)
                .Include(t => t.trait)
                .ToList();
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetItem(int id)
        {
            var item = context.Items
                .Include(r => r.rarity)
                .Include(e => e.enchantment)
                .Include(s => s.set)
                .Include(t => t.trait)
                .SingleOrDefault(i => i.id == id);
                
            if (item == null)
            {
                return NotFound();

            }
            return Ok(item);
        }
        [Route("weapons")]
        [HttpGet]
        public List<Weapon> GetAllWeapons()
        {
            /*IQueryable<Item> query = context.Items;
            query = query
                .Where(i => i.item_type == "weapon");

            return query.ToList();
            */
            return context.Items
                .Include(r => r.rarity)
                .Include(e => e.enchantment)
                .Include(s => s.set)
                .Include(t => t.trait)
                .OfType<Weapon>().ToList();

        }
        [Route("armors")]
        [HttpGet]
        public List<Armor> GetAllArmors()
        {
            /*IQueryable<Item> query = context.Items;
            query = query
                .Where(i => i.item_type == "armor");
                
            return query.ToList();*/

            return context.Items
                .Include(r => r.rarity)
                .Include(e => e.enchantment)
                .Include(s => s.set)
                .Include(t => t.trait)
                .OfType<Armor>().ToList();
        }
        [HttpPost]
        [Route("weapons")]
        public IActionResult CreateWeapon([FromBody] Weapon weapon)
        {
            context.Items.Add(weapon);
            context.SaveChanges();
            return Created("", GetItem(weapon.id));
        }
        [HttpPost]
        [Route("armors")]
        public IActionResult CreateArmor([FromBody] Armor armor)
        {
            context.Items.Add(armor);
            context.SaveChanges();
            return Created("", GetItem(armor.id));
        }
        [HttpPut]
        [Route("weapons")]
        public IActionResult UpdateWeapon([FromBody] Weapon updateWeapon)
        {
            Weapon orgWeapon = (Weapon)context.Items.Find(updateWeapon.id);
            if (orgWeapon == null)
            {
                return NotFound();
            }
            orgWeapon.name = updateWeapon.name;
            orgWeapon.value = updateWeapon.value;
            orgWeapon.traitid = updateWeapon.traitid;
            orgWeapon.rarityid = updateWeapon.rarityid;
            orgWeapon.setid = updateWeapon.setid;
            orgWeapon.enchantmentid = updateWeapon.enchantmentid;
           // orgWeapon.item_type = updateWeapon.item_type;
            orgWeapon.damage = updateWeapon.damage;
            orgWeapon.charge = updateWeapon.charge;
            context.SaveChanges();
            return Ok(GetItem(orgWeapon.id));
        }
        [HttpPut]
        [Route("armors")]
        public IActionResult UpdateArmor([FromBody] Armor updateArmor)
        {
            Armor orgArmor = (Armor)context.Items.Find(updateArmor.id);
            if (orgArmor == null)
            {
                return NotFound();
            }
            orgArmor.name = updateArmor.name;
            orgArmor.value = updateArmor.value;
            orgArmor.traitid = updateArmor.traitid;
            orgArmor.rarityid = updateArmor.rarityid;
            orgArmor.setid = updateArmor.setid;
            orgArmor.enchantmentid = updateArmor.enchantmentid;
            //orgArmor.item_type = updateArmor.item_type;
            orgArmor.durability = updateArmor.durability;
            orgArmor.armorRating = updateArmor.armorRating;
            orgArmor.armortype = updateArmor.armortype;
            context.SaveChanges();
            return Ok(GetItem(orgArmor.id));
        }
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            var item = context.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.Items.Remove(item);
            context.SaveChanges();
            return NoContent();
        }
    }
}

