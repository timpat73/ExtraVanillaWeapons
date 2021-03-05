using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ExtraVanillaWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items
{
    public class BlackHoleSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots tracking abyssal anomalies\n\"Unconceivable power in the palms of your hands, and you use it to kill slimes\"");
            DisplayName.SetDefault("Abyssal Looking Glass");
        }


        public override void SetDefaults()
        {            
            item.damage = 15;
            item.magic = true;
            item.mana = 25;
            item.width = 48;
            item.height = 48;
            item.scale = 1.6f;
            item.useTime = 20; 
            item.useAnimation = 20;
            item.reuseDelay = 30;
            item.useStyle = 4; 
            item.knockBack = 5f; 
            item.value = Item.buyPrice(5, 0, 0, 0); 
            item.rare = 6; 
            item.autoReuse = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item9;
            item.shootSpeed = 5f;
            item.shoot = ModContent.ProjectileType<BlackHoleSpear>();          
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2 + Main.rand.Next(3);
            float rotation = MathHelper.ToRadians(30);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, 15, 0f, player.whoAmI);
            }
            
            return false;
        }
        
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 50);
		}

    }
}