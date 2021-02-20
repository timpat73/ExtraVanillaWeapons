using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Projectiles 
{
	public class RocketJumpProjectile : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.width = 128;
			projectile.height = 128;
			projectile.aiStyle = -1;
			projectile.timeLeft = 60;
			projectile.penetrate = -1;
			projectile.tileCollide = true;
			projectile.friendly = true;
		}
		
		public override void AI()
		{
			for (int i = 0; i < 30; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 110, 0f, 0f, 0, new Color(0, 180, 0), 1.5f);
			}
		}
	}
}
        
        

    
