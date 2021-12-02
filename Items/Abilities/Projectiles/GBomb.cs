using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Dusts;

namespace ROTMG_Items.Items.Abilities.Projectiles
{
	public class GBomb : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
		}
		public override void AI()
		{
			projectile.velocity *= 0.01f;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item62, projectile.position);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("GhostlyExplosion"), 2000, 30f, projectile.owner, 0f, 0f);
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, ModContent.DustType<GhostlyDust>(), 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
			}
		}
	}
}