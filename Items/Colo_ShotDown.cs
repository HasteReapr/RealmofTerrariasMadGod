using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;

namespace ROTMG_Items.Items
{
	public class Colo_ShotDown : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 60;
		}

		public override void AI()
		{
			const double amp = -3;
			const double freq = -0.01;
			projectile.velocity = projectile.velocity.RotatedBy(projectile.ai[0] * projectile.timeLeft - (float)(Math.Sin(freq * projectile.timeLeft) * amp * freq));
			projectile.rotation = projectile.velocity.ToRotation();
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