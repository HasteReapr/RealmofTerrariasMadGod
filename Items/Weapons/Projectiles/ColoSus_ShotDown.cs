using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
	public class ColoSus_ShotDown : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 180;
		}

		public override void AI()
		{
			float multiplier = -1;
			const double amp = 15;
			const double freq = -0.01;
			projectile.velocity = projectile.velocity.RotatedBy(projectile.ai[0] * projectile.timeLeft + (float)(Math.Cos((freq * projectile.timeLeft) * amp * freq) * multiplier));
			projectile.rotation = projectile.velocity.ToRotation();
			multiplier *= -1f;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item1, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.25f;
		}
	}
}