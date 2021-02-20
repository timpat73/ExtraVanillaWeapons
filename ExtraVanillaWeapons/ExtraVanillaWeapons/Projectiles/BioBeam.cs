using System; 
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Projectiles 
{
    public class BioBeam : ModProjectile 
    {
        public override void SetDefaults()
        {
            projectile.width = 128; 
            projectile.height = 16; 
            projectile.aiStyle = 0; 
            projectile.timeLeft = 60; 
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.scale = 1.5f;
            projectile.light = 1.5f;
            projectile.damage = 10;
            projectile.hide = true;
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            
            drawCacheProjsBehindNPCsAndTiles.Add(index);

        }
    }
}
        
        

    
