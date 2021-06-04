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
    //[Authorize]
    [Route("api/v1")]
    public class PlayerItemController:Controller
    {
        private readonly ESOTrialContext context;
        public PlayerItemController(ESOTrialContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<PlayerItem> GetAllPlayerItems()
        {
            return context.PlayerItems
                .Include(i => i.item)
                .ThenInclude(i => i.rarity)
                .Include(i => i.item)
                .ThenInclude(i => i.enchantment)
                .Include(i => i.item)
                .ThenInclude(i => i.set)
                .Include(i => i.item)
                .ThenInclude(i => i.trait)
                .Include(i => i.player)
                .ToList();
        }
        [Route("players/{playerid}/items")]
        [HttpGet]
        public List<PlayerItem> GetItemsForPlayer(int playerid)
        {
            IQueryable<PlayerItem> query = context.PlayerItems;
            query = query
                .Where(i => i.playerid == playerid);
            return query
                .Include(i => i.item)
                .ThenInclude(i => i.rarity)
                .Include(i => i.item)
                .ThenInclude(i => i.enchantment)
                .Include(i => i.item)
                .ThenInclude(i => i.set)
                .Include(i => i.item)
                .ThenInclude(i => i.trait)
                .Include(i => i.player)
                .ToList();
        }


        [Route("items/{itemid}/players")]
        [HttpGet]
        public List<PlayerItem> GetPlayersForItem(int itemid)
        {
            IQueryable<PlayerItem> query = context.PlayerItems;
            query = query
                .Where(i => i.itemid == itemid);
            return query
                .Include(i => i.item)
                .ThenInclude(i => i.rarity)
                .Include(i => i.item)
                .ThenInclude(i => i.enchantment)
                .Include(i => i.item)
                .ThenInclude(i => i.set)
                .Include(i => i.item)
                .ThenInclude(i => i.trait)
                .Include(i => i.player)
                .ToList();
        }
/*        [HttpPost]
        public IActionResult CreatePlayerItem([FromBody] PlayerItem playerItem)
        {
            context.PlayerItems.Add(playerItem);
            context.SaveChanges();
            return Created("", playerItem); // hier moet nog aangepast worden
        }
        [HttpPut]
        public IActionResult UpdatePlayerItem([FromBody] PlayerItem updatePlayerItem)
        {
            PlayerItem orgPlayerItem = context.PlayerItems
                .FirstOrDefault(e => e.itemid == updatePlayerItem.itemid && e.playerid == updatePlayerItem.playerid);
            if (orgPlayerItem == null)
            {
                return NotFound();
            }
            orgPlayerItem.playerid = updatePlayerItem.playerid;
            orgPlayerItem.itemid = updatePlayerItem.itemid;
            if (context.SaveChanges() < 1)
            {
                return new StatusCodeResult(304);
            }
            
            return Ok(orgPlayerItem);
        }*/
    }
}
