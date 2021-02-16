using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Projectiles 
{
    public class Meatball : ModProjectile 
    {
        
        

        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.width = 16; 
            projectile.height = 16; 
            projectile.aiStyle = 0; 
            projectile.timeLeft = 600; 
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.hostile = true;
            projectile.scale = 2f;
            projectile.light = 1f;
            projectile.damage = 10;
        }

        public override void AI()
        {
            projectile.rotation += 0.1f;
            if (++projectile.frameCounter >= 10)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 2)
                {
                    projectile.frame = 0;
                }
            }

        }
    }
}
        
        

    
