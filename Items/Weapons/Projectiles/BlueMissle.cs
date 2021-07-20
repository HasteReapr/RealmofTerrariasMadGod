using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
	public class BlueMissle : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 12;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
		}

		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("BlueMissle2"), 700, 0f, projectile.owner, 0f, 0f);
		}
	}
}