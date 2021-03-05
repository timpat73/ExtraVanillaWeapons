using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items 
{
    public class SkullShooterUpgrade2 : ModItem 
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots clothier skulls\nHas a chance to shoot 7 extra skulls, bone arrows, or bouncing crossbones\n\"I've got WAY too many skulls to pick with you\"\n\"Truly feather worthy.\"");
            DisplayName.SetDefault("The Dungeon's Pandemonium");
        }


        public override void SetDefaults()
        {
            item.damage = 200; 
            item.magic = true; 
            item.noMelee = true; 
            item.width = 32; 
            item.height = 32; 
            item.useTime = 12; 
            item.useAnimation = 12; 
            item.reuseDelay = 0;
            item.useStyle = 5; 
            item.knockBack = 5f; 
            item.value = Item.buyPrice(5, 0, 0, 0); 
            item.rare = 10; 
            item.autoReuse = true; 
            item.shoot = 585; 
            item.shootSpeed = 10; 
            item.UseSound = SoundID.Item20;
            item.mana = 40;
        }

        


        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Random rd = new Random();

            int rand_x = rd.Next(1, 4);

            for (int i = 0; i < 7; i++)
            {
                if (rand_x == 1)
                {
                    Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed3.X * 0.3f, perturbedSpeed3.Y * 0.3f, 270, damage, knockBack, player.whoAmI);
                }
                else if (rand_x == 2)
                {
                    Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(60));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, 532, damage, knockBack, player.whoAmI);
                }
                else if (rand_x == 3)
                {
                    Vector2 perturbedSpeed1 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed1.X * 2f, perturbedSpeed1.Y * 2f, 117, damage, knockBack, player.whoAmI);
                }
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI); 

            }
            return false;



        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(154, 1500);
            recipe.AddIngredient(1508, 60);
            recipe.AddIngredient(3467, 20);
            recipe.AddIngredient(3457, 20);
            recipe.AddIngredient(3541, 1);
            recipe.AddIngredient(320, 1);
            recipe.AddIngredient(ModContent.ItemType<SkullShooterUpgrade1>(), 1);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}