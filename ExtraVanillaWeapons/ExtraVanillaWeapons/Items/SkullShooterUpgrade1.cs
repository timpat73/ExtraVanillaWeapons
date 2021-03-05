using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items 
{
    public class SkullShooterUpgrade1 : ModItem 
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots clothier skulls\nHas a chance to shoot 3 extra skulls\n\"I've got even more skulls to pick with you\"");
            DisplayName.SetDefault("The Dungeon's Chaos");
        }


        public override void SetDefaults()
        {
            item.damage = 75; 
            item.magic = true;  
            item.noMelee = true;
            item.width = 32; 
            item.height = 32; 
            item.useTime = 15; 
            item.useAnimation = 15; 
            item.reuseDelay = 0;
            item.useStyle = 5; 
            item.knockBack = 5f; 
            item.value = Item.buyPrice(5, 0, 0, 0); 
            item.rare = 8; 
            item.autoReuse = true; 
            item.shoot = 585; 
            item.shootSpeed = 10; 
            item.UseSound = SoundID.Item20;
            item.mana = 30;
        }

        


        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Random rd = new Random();

            int rand_x = rd.Next(-500, 500);

            for (int i = 0; i < 3; i++) 
            {
                if (rand_x >= 250)
                {
                    Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed3.X * 0.3f, perturbedSpeed3.Y * 0.3f, 270, damage, knockBack, player.whoAmI);
                }
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI); 

            }
            return false;



        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(557, 3);
            recipe.AddIngredient(1508, 15);
            recipe.AddIngredient(154, 150);
            recipe.AddIngredient(ModContent.ItemType<SkullShooter>(), 1);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}