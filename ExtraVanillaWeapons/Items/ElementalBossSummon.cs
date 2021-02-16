using ExtraVanillaWeapons.NPCs.ElementalBoss;
using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Items 
{
    public class ElementalBossSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons an Elemental Instability");
            DisplayName.SetDefault("Elemental Disc");
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
                NPC.SpawnOnPlayer(Player.whoAmI, mod.NPCType("ElementalBoss"));
            }
            return true;
        }
    }
}