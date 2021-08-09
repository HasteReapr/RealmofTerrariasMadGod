using ROTMG_Items.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace ROTMG_Items.Items.Abilities
{
	public class Scepter_Projectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 30;
			projectile.penetrate = 4;
			projectile.tileCollide = false;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
			int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.ScepterDust>(), 0f, 0f, 0, default(Color), 0.8f);
			Main.dust[dustnumber].velocity *= 0.3f;
			Main.dust[dustnumber].velocity *= 0.5f;
			Main.dust[dustnumber].velocity *= 0.7f;


			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && projectile.Distance(Main.npc[k].Center) < 300f)
				{
					projectile.velocity = Vector2.Normalize(Main.npc[k].Center - projectile.Center) * 16f;
				}
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//private List<NPC> npcs = null; //figure out how to use lists, eventually.
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && projectile.Distance(Main.npc[k].Center) < 300f)
				{
					projectile.velocity = Vector2.Normalize(Main.npc[k].Center - projectile.Center) * 160f;
				}
			}
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{

		}
	}
}