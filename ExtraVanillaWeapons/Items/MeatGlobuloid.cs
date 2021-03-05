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
    public class MeatGlobuloid : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Smells like meat, probably shouldn't eat it though");
            DisplayName.SetDefault("Meaty Glob");
        }


        public override void SetDefaults()
        {
            item.noMelee = true; 
            item.width = 13; 
            item.height = 13;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 5, 0, 0); 
            item.rare = 4;
        }


    }

    public class MeatyGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if ((npc.type == 113))
            {
                Item.NewItem(npc.getRect(), mod.ItemType("MeatGlobuloid"), Main.rand.Next(15, 31));
            }
        }
    }
}