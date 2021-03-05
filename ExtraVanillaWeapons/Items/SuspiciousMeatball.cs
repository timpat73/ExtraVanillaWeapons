using ExtraVanillaWeapons.NPCs.ElementalBoss;
using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items 
{
    public class SuspiciousMeatball : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons PATIENT {57X}\n\"He was supposed to die, but they didn't let him die.\nAfter his death his body was reborn, now forged in metal.\nAfter his second death he became more machine than man.\nEventually his body started regrowing. But it all went wrong.\nWith the absence of the world's guardian, the Wall of Flesh, his body's inner evils started escaping.\nNow he is tormented. Release his mind, hero. Break the chain.\"");
            DisplayName.SetDefault("Suspicious Meatball");
        }

        public override void SetDefaults()
        {
            item.noMelee = true; 
            item.width = 16; 
            item.height = 16; 
            item.useTime = 20; 
            item.useAnimation = 20;           
            item.useStyle = 4; 
            item.value = Item.buyPrice(5, 0, 0, 0); 
            item.rare = 10; 
        }

        public override bool UseItem(Player Player)
        {
            Main.PlaySound(SoundID.Roar, Player.position);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(Player.whoAmI, mod.NPCType("BioBorg"));
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1225, 20);
            recipe.AddIngredient(ModContent.ItemType<MeatGlobuloid>(), 90);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}