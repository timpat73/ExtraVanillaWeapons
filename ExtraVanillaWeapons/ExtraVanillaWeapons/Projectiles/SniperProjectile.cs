using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Projectiles 
{
    public class SniperProjectile : ModProjectile 
    {
        public override void SetDefaults()
        {
            projectile.width = 60; 
            projectile.height = 28; 
            projectile.aiStyle = 19; 
            projectile.timeLeft = 30; 
            projectile.penetrate = -1;
			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}

		
		
		public float movementFactor 
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}

		
		public override void AI()
		{
			
			
			Player projOwner = Main.player[projectile.owner];
			
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 1.5);
			
			if (!projOwner.frozen)
			{
				if (movementFactor == 0f) 
				{
					movementFactor = 1.5f; 
					projectile.netUpdate = true; 
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 1.5) 
				{
					movementFactor -= 1.0f;
				}
				else 
				{
					movementFactor += 1.2f;
				}
			}
			
			projectile.position += projectile.velocity * movementFactor;
			
			if (projOwner.itemAnimation == 0)
			{
				projectile.Kill();
			}
			
			
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(5f);
			
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(90f);
			}

			
			
		}
	}
}
        
        

    
