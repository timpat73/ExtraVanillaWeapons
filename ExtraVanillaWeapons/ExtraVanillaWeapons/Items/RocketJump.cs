using ExtraVanillaWeapons.Dusts;
using ExtraVanillaWeapons.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI.Chat;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items 
{
    public class RocketJump : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Launches you backwards at extremely high speeds\nRequires rockets to use\n\"You should learn to control the recoil\"");
            DisplayName.SetDefault("Otherworldy Leaf Blower");
        }


        public override void SetDefaults()
        {
            item.damage = 50;
            item.ranged = true;
            item.noMelee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 10;
            item.useAnimation = 10;
            item.reuseDelay = 120;
            item.useStyle = 5;
            item.value = Item.buyPrice(5, 0, 0, 0);
            item.rare = 6;
            item.autoReuse = true;
            item.UseSound = SoundID.Item11;
            item.shoot = item.shoot = ModContent.ProjectileType<RocketJumpProjectile>();
            item.shootSpeed = 12f;
            item.scale = 2.3f;
            item.useAmmo = AmmoID.Rocket;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            
            

            Vector2 mousePosition = Main.MouseWorld;
            float speed = 45f;
            Vector2 move = mousePosition - player.Center;
            float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            player.velocity = -move;
            for (int i = 0; i < 60; i++)
            {
                Dust.NewDust(player.position, player.width, player.height, 110, 0f, 0f, 0, new Color(0, 180, 0), 1.5f);
            }
            return false;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/RocketJump_Glow");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-34, -7);
        }
    }
}