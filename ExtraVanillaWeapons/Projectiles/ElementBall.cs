using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Projectiles 
{
    public class ElementBall : ModProjectile 
    {
        public override void SetDefaults()
        {
            projectile.width = 16; 
            projectile.height = 16; 
            projectile.aiStyle = 0;
            projectile.timeLeft = 600; 
            projectile.penetrate = -1;
			projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.scale = 1.5f;
            projectile.light = 1.5f;
            projectile.damage = 10;
        }

		
		
	}
}
        
        

    
