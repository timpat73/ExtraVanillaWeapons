using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ExtraVanillaWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items //where it's stored, replace Mod with the name of your mod. This file is stored in the folder \Mod Sources\(mod name, folder can't have spaces)\Projectiles.
{
    public class BlackHoleSword : ModItem //the class of the projectile. Change ProjectileSkeleton to whatever you want the projectile name to be.
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Press <right> to pull in enemies to your position\n\"Stare into the abyss, and it shall ignore you. Use the abyss to poke some slimes and it might get annoyed at you.\"");
            DisplayName.SetDefault("The Abyssal Looking Glass");
        }


        public override void SetDefaults()
        {            
            item.damage = 150; 
            item.ranged = true; 
            item.noMelee = true; 
            item.width = 44;
            item.height = 14;
            item.useTime = 10; 
            item.useAnimation = 10; 
            item.reuseDelay = 20;
            item.useStyle = 5; 
            item.knockBack = 5f; 
            item.value = Item.buyPrice(5, 0, 0, 0); 
            item.rare = 8; 
            item.autoReuse = true; 
            item.UseSound = SoundID.Item11;
            item.shootSpeed = 10;
            item.crit = 29;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.damage = 150;
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.useAnimation = 18;
                item.useTime = 24;
                item.shootSpeed = 3.7f;
                item.knockBack = 6.5f;
                item.width = 32;
                item.height = 32;
                item.scale = 1f;
                item.rare = ItemRarityID.Pink;
                item.value = Item.sellPrice(silver: 10);

                item.melee = true;
                item.noMelee = true; 
                item.noUseGraphic = true; 
                item.autoReuse = true; 

                item.UseSound = SoundID.Item1;
                item.shoot = ModContent.ProjectileType<BlackHoleSpear>();
            }

            else
            {
                item.damage = 150;
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.useAnimation = 18;
                item.useTime = 24;
                item.shootSpeed = 3.7f;
                item.knockBack = 6.5f;
                item.width = 32;
                item.height = 32;
                item.scale = 1f;
                item.rare = ItemRarityID.Pink;
                item.value = Item.sellPrice(silver: 10);

                item.melee = true;
                item.noMelee = true; 
                item.noUseGraphic = true; 
                item.autoReuse = true; 

                item.UseSound = SoundID.Item1;
                item.shoot = ModContent.ProjectileType<BlackHoleSpear>();
            }

            return base.CanUseItem(player);
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        

        
    }
}