using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.NPCs.Projectiles
{
	public class DreadArrow : ModProjectile
	{
        public override string Texture => "ROTMG_Items/Items/Weapons/Projectiles/DBow_Arrow";
        public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.hostile = true;
			projectile.penetrate = 8;
			projectile.timeLeft = 40;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
		}
	}
}