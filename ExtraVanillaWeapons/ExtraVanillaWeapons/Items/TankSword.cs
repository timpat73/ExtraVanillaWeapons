using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ExtraVanillaWeapons.Projectiles;
using ExtraVanillaWeapons.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items 
{
    public class TankSword : ModItem 
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Press <right> to give yourself 20 defense but decreased movement speed and melee speed for 10 seconds");
            DisplayName.SetDefault("Elemental Bulwark");
        }


        public override void SetDefaults()
        {            
            item.damage = 100; 
            item.melee = true; 
            item.noMelee = false; 
            item.width = 32; 
            item.height = 32; 
            item.useTime = 22; 
            item.useAnimation = 22; 
            item.reuseDelay = 0;
            item.useStyle = 1; 
            item.knockBack = 5f; 
            item.value = Item.buyPrice(5, 0, 0, 0); 
            item.rare = 8; 
            item.autoReuse = true;
            item.UseSound = SoundID.Item11;
            item.shootSpeed = 10;
            item.scale = 3.3f;
        }       

        

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 4;
                item.useTime = 40;
                item.useAnimation = 40;
                item.reuseDelay = 0;
                item.damage = 400;
                item.buffType = ModContent.BuffType<Buffs.TankSwordBuff>(); 
                item.buffTime = 600; 
            }
            else
            {   
                item.useStyle = 1;
                item.useTime = 22;
                item.useAnimation = 22;
                item.buffType = 0;
            }
            return base.CanUseItem(player);
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        

        
    }
}