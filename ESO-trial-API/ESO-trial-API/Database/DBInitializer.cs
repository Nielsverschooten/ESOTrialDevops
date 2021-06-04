using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESO_trial_API.Models;
using Microsoft.EntityFrameworkCore;
namespace ESO_trial_API.Database
{
    public class DBInitializer
    {
        public static void Initialize(ESOTrialContext context)
        {
            context.Database.EnsureCreated();
            Weapon weapon1 = null;
            Armor armor1 = null;
            Rarity normal = null;
            Rarity fine = null;
            Rarity superior = null;
            Rarity epic = null;
            Rarity legendary = null;
            Set MothersSorrow = null;
            Set Zaan = null;
            Set Pfg = null;
            Enchantment IncreaseMagicka = null;
            Enchantment FireDamage = null;
            Enchantment PoisonDamage = null;
            Enchantment Berserker = null;
            Trait precise = null;
            Trait divines = null;
            Trait infused = null;
            Trait training = null;
            Trait sharpened = null;
            Player player1 = null;
            PlayerItem playerItem = null;

            if (!context.Rarities.Any())
            {
                normal = new Rarity
                {
                    name = "Normal",
                    items = new List<Item>()
                };
                fine = new Rarity
                {
                    name = "Fine",
                    items = new List<Item>()
                };
                superior = new Rarity
                {
                    name = "Superior",
                    items = new List<Item>()
                };
                epic = new Rarity
                {
                    name = "Epic",
                    items = new List<Item>()
                };
                legendary = new Rarity
                {
                    name = "Legendary",
                    items = new List<Item>()
                };

                context.Rarities.Add(normal);
                context.Rarities.Add(fine);
                context.Rarities.Add(superior);
                context.Rarities.Add(epic);
                context.Rarities.Add(legendary);
                context.SaveChanges();

            }
            if (!context.Players.Any())
            {
                player1 = new Player
                {
                    name = "nielsxformer",
                    characterName = "Icydeadpeeps",
                    level = 50,
                    cp=810,
                    playeritems = new List<PlayerItem>()
                    
                };
                context.Players.Add(player1);
                context.SaveChanges();
            }
            if (!context.Traits.Any())
            {
                precise = new Trait
                { 
                      name = "Precise",
                      effect = "Increases Weapon and Spell Critical values",
                      items = new List<Item>()
                };
                divines = new Trait
                {
                    name = "Divines",
                    effect = "Increases Mundus Stone effects",
                    items = new List<Item>()
                };
                infused = new Trait
                {
                    name = "Infused",
                    effect = "Increases enchantment effects",
                    items = new List<Item>()
                };
                sharpened = new Trait
                {
                    name = "Sharpened",
                    effect = "Increases armor en spell penetration",
                    items = new List<Item>()
                };
                training = new Trait
                {
                    name = "Training",
                    effect = "Increases experience gain",
                    items = new List<Item>()
                };
                context.Traits.Add(precise);
                context.Traits.Add(divines);
                context.Traits.Add(infused);
                context.Traits.Add(sharpened);
                context.Traits.Add(training);
                context.SaveChanges();
            }
            if (!context.Sets.Any())
            {
                MothersSorrow = new Set
                {
                    name = "Mother's Sorrow",
                    description = "(2 items) Adds 1096 Maximum Magicka \n (3 items) Adds 657 Spell Critical \n (4 items) Adds 657 Spell Critical \n (5 items) Adds 1528 Spell Critical",
                    items = new List<Item>()
                };
                Zaan = new Set
                {
                    name = "Zaan",
                    description = "(1 item) Adds 657 Spell Critical \n (2 items) When you damage a nearby enemy with a Light or Heavy Attack, you have a 33 % chance to create a beam of fire that will connect you to your enemy.The beam deals 2010 Flame damage every 1 second to your enemy for 6 seconds.Every second, this damage increases by 100 %.The beam is broken if the enemy moves 8 meters away from you.This effect can occur every 18 seconds.",
                    items = new List<Item>()
                };
                Pfg = new Set
                {
                    name = "Perfected Fals God's Devotion",
                    description = "(2 items) Adds 657 Spell Critical \n (3 items) Gain Minor Slayer at all times, increasing your damage done to Dungeon, Trial, and Arena Monsters by 5%. \n (4 items) Adds 657 Spell Critical \n (5 items) Adds 129 Spell Damage, Reduces the cost of your Magicka Abilities by 8%. When an enemy you recently damaged dies, you restore 2454 Magicka and gain Major Expedition for 8 seconds, increasing your Movement Speed by 30%. These effects can occur once every second.",
                    items = new List<Item>()
                };
                
                context.Sets.Add(MothersSorrow);
                context.Sets.Add(Zaan);
                context.Sets.Add(Pfg);
                context.SaveChanges();
            }
            if (!context.Enchantments.Any())
            {
                IncreaseMagicka = new Enchantment
                {
                    name = "Truly Superb Glyph of Magicka",
                    effect = "Increases maximum Magicka by 868",
                    items = new List<Item>()
                };
                FireDamage = new Enchantment
                {
                    name = "Truly Superb Glyph of Flame",
                    effect = "Deals 2534 Flame damage on hit",
                    items = new List<Item>()
                };
                PoisonDamage = new Enchantment
                {
                    name = "Truly Superb Glyph of Poison",
                    effect = "Deals 2534 Poison damage on hit",
                    items = new List<Item>()
                };
                Berserker = new Enchantment
                {
                    name = "Truly Superb Glyph of Weapon Damage",
                    effect = "Increases Weapon and Spell Damage by 384 for 5 Seconds on hit",
                    items = new List<Item>()
                };
                context.Enchantments.Add(IncreaseMagicka);
                context.Enchantments.Add(FireDamage);
                context.Enchantments.Add(PoisonDamage);
                context.Enchantments.Add(Berserker);
                context.SaveChanges();
            }
            if (!context.Items.Any())
            {
                weapon1 = new Weapon
                {
                    name = "Inferno staff of a mothers sorrow",
                    value = 200000,
                    rarity = legendary,
                    enchantment = FireDamage,
                    set = MothersSorrow,
                    trait = precise,
                    damage = 1875,
                    charge = 3000,
                    playeritems = new List<PlayerItem>()
                };
                armor1 = new Armor
                {
                    name = "Zaans guise",
                    value = 15000,
                    rarity = legendary,
                    enchantment = IncreaseMagicka,
                    set = Zaan,
                    trait = divines,
                    armorRating = 687,
                    durability = 1600,
                    armortype = "Light",
                    playeritems = new List<PlayerItem>()
                };
                context.Items.Add(weapon1);
                context.Items.Add(armor1);
                context.SaveChanges();
            }
            if (!context.PlayerItems.Any())
            {
                playerItem = new PlayerItem
                {
                    item = weapon1,
                    player = player1
                };
                context.PlayerItems.Add(playerItem);
                context.SaveChanges();
            }
        }
    }
}
