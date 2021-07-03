using ROTMG_Items.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
	public class t1Spell_Dust : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 15;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
		}
        public override void Kill(int timeLeft)
        {
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X * -1, projectile.velocity.Y * -1, mod.ProjectileType("t1Spell_Proj"), 10, 0f, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.rotation * 2f, projectile.rotation * 2f,projectile.velocity.X * -1, projectile.velocity.Y * -1, mod.ProjectileType("t1Spell_Proj"), 10, 0f, projectile.owner, 0f, 0f);
			}
    }
}