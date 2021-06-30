using ROTMG_Items.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class Splendor_Shot : ModProjectile
	{
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 25;
		}

		public override void AI() {
			projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = projectile.velocity.ToRotation();
		}

		public override void Kill(int timeLeft) {
			Main.PlaySound(SoundID.Item1, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}