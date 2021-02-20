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

namespace ExtraVanillaWeapons.Projectiles 
{
	public class BlackHole : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
			projectile.aiStyle = -1;
			projectile.timeLeft = 60;
			projectile.penetrate = -1;
			projectile.scale = 1.6f;
			projectile.alpha = 0;

			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}
		
		public override void AI()
		{
			
		}
	}
}
        
        

    
