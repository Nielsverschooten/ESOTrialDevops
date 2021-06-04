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
    [Route("api/v1/players")]
    public class PlayerController:Controller
    {
        private readonly ESOTrialContext context;
        public PlayerController(ESOTrialContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Player> GetAllPlayers()
        {
            return context.Players.ToList();
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetPlayer(int id)
        {
            var player = context.Players.SingleOrDefault(p => p.id == id);
            if (player == null)
            {
                return NotFound();

            }
            return Ok(player);
        }
        [HttpPost]
        public IActionResult CreatePlayer([FromBody] Player player)
        {
            context.Players.Add(player);
            context.SaveChanges();
            return Created("", GetPlayer(player.id));
        }
        [HttpPut]
        public IActionResult UpdatePlayer([FromBody] Player updatePlayer)
        {
            Player orgPlayer = context.Players.Find(updatePlayer.id);
            if (orgPlayer == null)
            {
                return NotFound();
            }
            orgPlayer.name = updatePlayer.name;
            orgPlayer.characterName = updatePlayer.characterName;
            orgPlayer.level = updatePlayer.level;
            orgPlayer.cp = updatePlayer.cp;
           // orgPlayer.playeritems = updatePlayer.playeritems;
            context.SaveChanges();
            return Ok(GetPlayer(orgPlayer.id));
        }
/*        [Route("{id}")]
        [HttpPut]
        public IActionResult AddItemForPlayer([FromBody] int itemId, int id)
        {
            Player orgPlayer = context.Players.Find(id);
            if (orgPlayer == null)
            {
                return NotFound();
            }
            Item itemToAdd = context.Items.Find(itemId);
            if (itemToAdd == null)
            {
                return NotFound();
            }
            orgPlayer.playeritems.Add(new PlayerItem
            {
                player = orgPlayer,
                item = itemToAdd
                

            });
            context.SaveChanges();
            return Ok(GetPlayer(id));
        }*/
        [Route("{id}/items/{itemId}")]
        [HttpPost]
        public IActionResult AddItemToPlayer(int id, int itemId)
        {
            Player player = context.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }
            Item item = context.Items.Find(itemId);
            if (item == null)
            {
                return NotFound();
            }
            PlayerItem pl = new PlayerItem
            {
                player = player,
                item = item
            };
            context.PlayerItems.Add(pl);
            context.SaveChanges();
            return Created("", pl);
           
        }
        [Route("{id}/items/{itemId}")]
        [HttpDelete]
        public IActionResult DeleteItemAndPlayerRelation(int id, int itemId)
        {
            IQueryable<PlayerItem> query = context.PlayerItems.Where(pl => pl.playerid == id && pl.itemid == itemId);
            if (query == null)
            {
                return NotFound();
            }
            context.PlayerItems.Remove(query.FirstOrDefault());
            context.SaveChanges();
            return NoContent();

        }


        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePlayer(int id)
        {
            var player = context.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }
            context.Players.Remove(player);
            context.SaveChanges();
            return NoContent();
        }
    }
}
