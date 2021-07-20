using Terraria;
using Terraria.ModLoader;
using System;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
	public class BlueMissle2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 60;
		}
		public float randomdir = Main.rand.Next(1, 360);
		public override void AI()
		{
			randomdir = Main.rand.Next(1, 360);
			projectile.rotation = projectile.velocity.ToRotation();
			projectile.velocity = projectile.velocity.RotatedBy(Math.Cos((randomdir * randomdir) * 0.07f));
		}
	}
}