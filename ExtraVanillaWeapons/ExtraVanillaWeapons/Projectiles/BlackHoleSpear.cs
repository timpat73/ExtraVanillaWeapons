using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Projectiles 
{
	public class BlackHoleSpear : ModProjectile 
	{
        public bool isAttached = false;

        public bool targetFound = false;
        public int spawnTime = 60;
        
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.scale = 0.001f;
			projectile.alpha = 50;
			projectile.light = 1.5f;
			projectile.timeLeft = 120;

			projectile.ranged = true;
			projectile.tileCollide = false;
			projectile.friendly = true;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

		
		public override void AI()
		{
            if (++projectile.frameCounter >= 10)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            if (targetFound == true)
            {
                

                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];

                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 150f && !target.friendly && target.active)
                    {
                        
                        if (isAttached == false)
                        {
                            projectile.timeLeft = 180;
                            isAttached = true;
                        }
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }

                }
            }
            else if (spawnTime <= 0)
            {
                targetFound = true;                
            }
            else 
            {
                spawnTime -= 1;
                projectile.scale += 0.02f;
            }
        }
	}
}
        
        

    
