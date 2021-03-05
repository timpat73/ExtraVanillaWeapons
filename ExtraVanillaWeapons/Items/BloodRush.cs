using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ExtraVanillaWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items 
{
    public class BloodRush : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Press <right> to dash towards your cursor (this does not make you invincible so watch out)\n\"This... thing... somehow injects enough adrenaline into your body to power a small car\"");
            DisplayName.SetDefault("Blood Rush");
        }


        public override void SetDefaults()
        {            
            item.damage = 30; 
            item.melee = true;
            item.width = 46;
            item.height = 41;
            item.useTime = 9; 
            item.useAnimation = 9;
            item.useStyle = 1;
            item.knockBack = 5f;
            item.value = Item.buyPrice(5, 0, 0, 0); 
            item.rare = 8;
            item.scale = 1.3f;
            item.autoReuse = true; 
            item.UseSound = SoundID.Item19;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.autoReuse = false;
                item.useTime = 60;
                item.useAnimation = 60;
                item.knockBack = 25f;
                item.useStyle = 3;

                Vector2 mousePosition = Main.MouseWorld;
                float speed = 11.666f;
                Vector2 move = mousePosition - player.Center;
                float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                if (magnitude > speed)
                {
                    move *= speed / magnitude;
                }
                player.velocity = move;
            }
            else
            {
                item.autoReuse = true;
                item.useTime = 9;
                item.useAnimation = 9;
                item.knockBack = 5f;
                item.useStyle = 1;
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(521, 10);
            recipe.AddIngredient(1332, 15);
            recipe.AddIngredient(ModContent.ItemType<MeatGlobuloid>(), 15);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(521, 10);
            recipe.AddIngredient(522, 15);
            recipe.AddIngredient(ModContent.ItemType<MeatGlobuloid>(), 15);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}