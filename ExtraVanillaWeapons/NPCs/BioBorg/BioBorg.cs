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

namespace ExtraVanillaWeapons.NPCs.BioBorg
{
	
	public class BioBorg : ModNPC
	{
		public bool lightColor2 = false;
		public int lightColor2Cool = 5;
		public bool fireAnim = false;

		public int laserCool = 60;
		public bool laserPhase = true;

		public int meatballCool = 120;
		public bool meatballPhase = false;
		public int meatballPhaseCool = 5;

		public int chargeCool = 100;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PATIENT {57X}");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 10000;
			npc.damage = 100;
			npc.defense = 30;
			npc.knockBackResist = 0f;
			npc.width = 54;
			npc.height = 64;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[24] = true;
			npc.scale = 2f;
			music = MusicID.Boss3;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}
		

		public override void AI()
		{
			

			npc.TargetClosest(false);
			Player player = Main.player[npc.target];
			//frikandel > meatball
			if (meatballPhase == true)
			{
                if (meatballPhaseCool == 0)
                {
					meatballPhase = false;
					laserPhase = true;
					meatballPhaseCool = 5;
					meatballCool = 120;
					fireAnim = false;
				}
				
				Vector2 moveTo = player.Center + new Vector2(-400f, -250f); 
				float speed = 50f;
				Vector2 move = moveTo - npc.Center;
				float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
				if (magnitude > speed)
				{
					move *= speed / magnitude;
				}
				npc.velocity = move;
				if (meatballCool <= 30)
				{
					fireAnim = true;
				}
				if (meatballCool <= 0)
				{
					
					fireAnim = true;


					float numberProjectiles = 6 + Main.rand.Next(5); 
					float rotation = MathHelper.ToRadians(120);
					npc.Center += Vector2.Normalize(new Vector2(15f, 15f)) * 45f;
					for (int i = 0; i < numberProjectiles; i++)
					{
						Vector2 perturbedSpeed = new Vector2(25f, 25f).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; 
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Meatball>(), 50, 0f, player.whoAmI);
					}
				}
                if (meatballCool <= -1)
                {
					meatballCool = 30;
					meatballPhaseCool -= 1;
				}
                if (meatballCool <= -30)
				{
					fireAnim = false;
				}
				else
				{
					meatballCool -= 1;
				}
			}
			//laser beam attack wowzers!
			if (laserPhase == true)
			{
				if (laserCool >= -30)
				{
					if (laserCool == -30)
					{
						Main.PlaySound(14);
					}
					Vector2 moveTo = player.Center + new Vector2(-300f, -50f); 
					float speed = 50f;
					Vector2 move = moveTo - npc.Center;
					float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
					if (magnitude > speed)
					{
						move *= speed / magnitude;
					}
					npc.velocity = move;
				}
				if (laserCool <= -60)
				{
					Projectile.NewProjectile(npc.Center.X + 70, npc.Center.Y, 50f, 0f, ModContent.ProjectileType<BioBeam>(), 200, 0f, Main.myPlayer, npc.whoAmI);

					if (laserCool == -60)
					{
						Main.PlaySound(26);

					}
					if (laserCool <= -70)
					{
						Vector2 recoil = npc.position + new Vector2(-1.5f, 0f);
						npc.position = recoil;
					}
					if (laserCool <= -100)
					{
						meatballPhase = true;
						laserPhase = false;
						fireAnim = false;
						laserCool = 300;
					}



				}
				else if (laserCool <= 0)
				{
					fireAnim = true;
				}
				if (laserCool >= -200)
				{
					laserCool -= 1;
				}
			}
			
			//animation stuff (do not touch i think)
			if (lightColor2Cool <= 0)
			{
				if (lightColor2 == false && fireAnim == false)
				{
					npc.frame.Y = 128;
					lightColor2 = true;
				}
				else if (lightColor2 == true && fireAnim == false)
				{
					npc.frame.Y = 0;
					lightColor2 = false;
				}
				else if (lightColor2 == false && fireAnim == true)
				{
					npc.frame.Y = 64;
					lightColor2 = true;
				}
				else if (lightColor2 == true && fireAnim == true)
				{
					npc.frame.Y = 192;
					lightColor2 = false;
				}
				lightColor2Cool = 5;
			}
			else
			{
			lightColor2Cool -= 1;
			}

				
			
		}
	}
}