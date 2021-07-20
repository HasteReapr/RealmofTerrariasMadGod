using Terraria.ModLoader;

namespace ROTMG_Items.NPCs.Projectiles
{
	public class Spooky_Slow_Shot : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.frameCounter = 7;
			projectile.width = 34;
			projectile.height = 34;
			projectile.hostile = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 180;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		float rotation = 1;
		public override void AI()
		{
			rotation += 0.1f;
			projectile.rotation = rotation;
		}
	}
}