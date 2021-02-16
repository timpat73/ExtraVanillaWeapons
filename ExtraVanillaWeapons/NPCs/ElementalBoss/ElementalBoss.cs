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
	[AutoloadBossHead]
	public class ElementalBoss : ModNPC
	{
		public int AttackPhaseCool = 400;
		public int NeutralPhaseCool = 120;
		public int AttackCool = 600;

		public bool Frame2 = false;

		public float SpinSpeed = 0.15f;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Instability");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 10000;
			npc.damage = 100;
			npc.defense = 999999;
			npc.knockBackResist = 0f;
			npc.width = 64;
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
			npc.scale = 2.5f;
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

			Vector2 moveTo = player.Center + new Vector2(150f, -450f); 
			npc.position = moveTo;
            
			if (!player.active || player.dead || NPC.downedPlantBoss == false)
			{
				for (int i = 0; i < 600; i++)
				{
					SpinSpeed += 0.1f;
					AttackCool = 500;
					Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<ElementalSmoke>(), 0f, 0f, 0, new Color(0, 180, 0), 1.5f);
					
				}
				npc.active = false;
			}
			if (player.active || !player.dead)
			{
				if (AttackCool <= 0)
				{
                    //phase start
                    
					if (Frame2 == false) //attack phase start
					{
						AttackCool = NeutralPhaseCool;
						SpinSpeed = 0.5f;
						npc.frame.Y = 64;
						Frame2 = true;
						npc.defense = 999999;
						if (npc.life <= 8000)
						{							
							NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 40, ModContent.NPCType<ElementalLeft>(), 0, npc.whoAmI, moveTo.X, moveTo.Y);
							NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 40, ModContent.NPCType<ElementalRight>(), 0, npc.whoAmI, moveTo.X, moveTo.Y);
						}
					}
					else if (Frame2 == true) //neutral phase start
					{
						AttackCool = AttackPhaseCool;
						SpinSpeed = 0.15f;
						npc.frame.Y = 0;
						Frame2 = false;
						npc.defense = 30;

						if (npc.life <= 4000)
                        {
							AttackPhaseCool = 120;
                        }
					}
				}
				else
				{
					//constantly
					AttackCool -= 1;
					

					if (Frame2 == true) //attack phase constantly
					{
						Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<ElementalSmokeAlt>(), 0f, 0f, 0, new Color(180, 0, 0), 1.5f);
						
						Random rd = new Random();
						int randNum = rd.Next(-14, 14);
						int randNum1 = rd.Next(-14, 14);
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, randNum, randNum1, ModContent.ProjectileType<ElementBall>(), 50, 0f, Main.myPlayer, npc.whoAmI);
						
					}
					else
					if (Frame2 == false) //neutral phase constantly
					{
						Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<ElementalSmoke>(), 0f, 0f, 0, new Color(0, 180, 0), 1.5f);
						
					}
				}
			}
		}
	}
}