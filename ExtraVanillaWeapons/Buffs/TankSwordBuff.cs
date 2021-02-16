using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ExtraVanillaWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Buffs
{
    public class TankSwordBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Elemental Bulwark");
            Description.SetDefault("Grants +20 defense but way slower movement and melee speed.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; 
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 20; 
            player.meleeSpeed -= 0.5f;
            player.moveSpeed -= 0.5f;
        }
    }
}