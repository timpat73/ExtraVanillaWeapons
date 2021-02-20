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

namespace ExtraVanillaWeapons.NPCs
{
    public class FucjkGlobalNPC : GlobalNPC
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