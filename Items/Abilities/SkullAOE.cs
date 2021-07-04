using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;
using ROTMG_Items.Dusts;

namespace ROTMG_Items.Items.Abilities
{
	public class SkullAOE : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.frameCounter = 7;
			projectile.width = 128;
			projectile.height = 128;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 3;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}

		public override void AI()
		{
			Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
			projectile.velocity = vectorToCursor;
			float distanceToCursor = vectorToCursor.Length();
			if (distanceToCursor == 0f)
			{
				projectile.velocity *= 0.01f;
			}
		}
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.SkullDust>(), 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 1f;
			}
		}
		public void SkullHeal(int dmg, Vector2 Position)
		{
			float num = (float)dmg * 0.5f;
			if ((int)num == 0)
			{
				return;
			}
			if (Main.player[Main.myPlayer].lifeSteal <= 0f)
			{
				return;
			}
			Main.player[Main.myPlayer].lifeSteal -= num;
			int num2 = projectile.owner;
			Projectile.NewProjectile(Position.X, Position.Y, 0f, 0f, ProjectileID.VampireHeal, 0, 0f, projectile.owner, (float)num2, num);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			SkullHeal(damage, projectile.Center);
        }
    }
}