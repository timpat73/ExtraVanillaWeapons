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
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.UI.Chat;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons
{
	public class World : ModWorld
	{
		public static bool downedElementalBoss;
		public static bool downedBioBorg;

		public override void Initialize()
		{
			downedElementalBoss = false;
			downedBioBorg = false;
		}

		
	}
}
