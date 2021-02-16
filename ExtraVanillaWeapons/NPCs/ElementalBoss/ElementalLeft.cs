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

namespace ExtraVanillaWeapons.NPCs.ElementalBoss
{
	
	public class ElementalLeft : ModNPC
	{
		public int AttackPhaseCool = 400;
		public int NeutralPhaseCool = 120;
		public int AttackCool = 600;
		public float Closeness = 350f;
		public bool Frame2 = false;

		public float SpinSpeed = -0.15f;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Instability");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 500;
			npc.damage = 1000;
			npc.defense = 70;
			npc.knockBackResist = 0f;
			npc.width = 32;
			npc.height = 32;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.npcSlots = 1f;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[24] = true;
			npc.scale = 4f;
			music = MusicID.Boss2;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		

		public override void AI()
		{
            
			
			npc.rotation += SpinSpeed;

			npc.TargetClosest(false);
			Player player = Main.player[npc.target];

			Vector2 moveTo = player.Center + new Vector2(Closeness, 0f); 
			npc.position = moveTo;
			
			
			if (!player.active || player.dead)
			{
				for (int i = 0; i < 600; i++)
				{
					SpinSpeed += 0.1f;
					AttackCool = 500;
					Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<ElementalSmokeAlt>(), 0f, 0f, 0, new Color(180, 0, 0), 1.5f);

				}
				npc.active = false;
			}
			if (player.active || !player.dead)
			{
				Closeness -= 1f;
				
				SpinSpeed = -0.5f;
				npc.frame.Y = 32;
				Frame2 = true;
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<ElementalSmokeAlt>(), 0f, 0f, 0, new Color(180, 0, 0), 1.5f);
				

				npc.defense = 60;
			}
		}
	}
}