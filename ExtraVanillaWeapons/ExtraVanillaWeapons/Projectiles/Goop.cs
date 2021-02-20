using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Projectiles 
{
    public class Goop : ModProjectile 
    {
        
        

        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            projectile.width = 32; 
            projectile.height = 32; 
            projectile.aiStyle = 0; 
            projectile.timeLeft = 600; 
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.scale = 2f;
            projectile.light = 1f;
            projectile.damage = 10;
        }       

        public override void AI()
        {
           

        }
    }
}
        
        

    
