using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ExtraVanillaWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items 
{
    public class Sniper : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots a high velocity bullet\nPress <right> to stab with the weapon");
            DisplayName.SetDefault("The Arms Dealer's Surprise");
        }


        public override void SetDefaults()
        {            
            item.damage = 100; 
            item.ranged = true; 
            item.noMelee = true; 
            item.width = 44; 
            item.height = 14; 
            item.useTime = 25; 
            item.useAnimation = 25;
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
                item.useStyle = 5;
                item.noUseGraphic = true;
                item.useTime = 25;
                item.useAnimation = 25;
                item.reuseDelay = 0;
                item.damage = 400;
                item.shoot = 0;
                item.shootSpeed = 3.7f;
                item.shoot = ModContent.ProjectileType<SniperProjectile>();
                item.useAmmo = AmmoID.None;
            }
            else
            {   
                item.useStyle = 5;
                item.noUseGraphic = false;
                item.useTime = 25;
                item.useAnimation = 25;
                item.damage = 100;
                item.shoot = 10;
                item.shootSpeed = 50;
                item.useAmmo = AmmoID.Bullet;
            }
            return base.CanUseItem(player);
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        

        
    }
}