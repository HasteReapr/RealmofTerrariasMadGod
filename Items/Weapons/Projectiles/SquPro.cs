using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
	public class SquPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 50;
			drawOffsetX = -15;
			drawOriginOffsetY = -3;
			drawOriginOffsetX = 6;
		}

		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation();
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item1, projectile.position);
		}
	}
}