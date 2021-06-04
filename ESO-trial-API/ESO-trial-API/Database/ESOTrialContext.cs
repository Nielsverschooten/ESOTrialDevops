using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ESO_trial_API.Models;

namespace ESO_trial_API.Database
{
    public class ESOTrialContext:DbContext
    {
        public ESOTrialContext()
        {

        }
        public ESOTrialContext(DbContextOptions<ESOTrialContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasDiscriminator<string>("item_type")
                .HasValue<Armor>("armor")
                .HasValue<Weapon>("weapon");
            modelBuilder.Entity<Item>()
                .HasOne(r => r.rarity)
                .WithMany(i => i.items)
                .HasForeignKey(i => i.rarityid)
               // .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            modelBuilder.Entity<Item>()
                .HasOne(r => r.enchantment)
                .WithMany(i => i.items)
                .HasForeignKey(i => i.enchantmentid)
             //   .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            modelBuilder.Entity<Item>()
                .HasOne(r => r.trait)
                .WithMany(i => i.items)
                .HasForeignKey(i => i.traitid)
            //    .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            modelBuilder.Entity<Item>()
                .HasOne(r => r.set)
                .WithMany(i => i.items)
                .HasForeignKey(i => i.setid)
            //    .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            modelBuilder.Entity<PlayerItem>()
                .HasKey(pi => new { pi.itemid, pi.playerid });
            modelBuilder.Entity<PlayerItem>()
                .HasOne(pi => pi.item)
                .WithMany(i => i.playeritems)
                .HasForeignKey(pi => pi.itemid);
            modelBuilder.Entity<PlayerItem>()
                .HasOne(pi => pi.player)
                .WithMany(i => i.playeritems)
                .HasForeignKey(pi => pi.playerid);
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Enchantment> Enchantments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }
        

    }
}
