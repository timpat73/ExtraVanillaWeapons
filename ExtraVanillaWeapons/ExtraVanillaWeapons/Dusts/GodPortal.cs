using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExtraVanillaWeapons.Dusts
{
	public class GodPortal : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.frame = new Rectangle(0, 0, 16, 16);
			dust.scale = 10f;
			dust.alpha = 155;
			
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.scale -= 0.01f;
			dust.rotation += 0.05f;
			if (dust.scale < 0.75f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}