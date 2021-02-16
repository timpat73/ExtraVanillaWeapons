using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items 
{
    public class SkullShooter : ModItem 
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots clothier skulls\n\"I've got a skull to pick with you\"");
            DisplayName.SetDefault("Clothier's Curse");
        }


        public override void SetDefaults()
        {
            item.damage = 50; 
            item.magic = true; 
            item.noMelee = true; 
            item.width = 32; 
            item.height = 32; 
            item.useTime = 20; 
            item.useAnimation = 20; 
            item.reuseDelay = 0;
            item.useStyle = 5; 
            item.knockBack = 5f; 
            item.value = Item.buyPrice(5, 0, 0, 0); 
            item.rare = 3; 
            item.autoReuse = true; 
            item.shoot = 585; 
            item.shootSpeed = 10; 
            item.UseSound = SoundID.Item11;
            item.mana = 20;
        }



        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {


            for (int i = 0; i < 1; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0)); 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI); 

            }
            return false;



        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1313);
            recipe.AddIngredient(260);
            recipe.AddIngredient(154, 30);
            recipe.AddTile(26);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}