using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;

namespace ROTMG_Items.Items.Abilities
{
	public class CoinParticle : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.frameCounter = 7;
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 1000;
			projectile.timeLeft = 1;
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
			Main.PlaySound(SoundID.Item1, projectile.position);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -5f, 10f, mod.ProjectileType("GoldenCoin"), 0, 0f, projectile.owner, 0f, 0f); //32 stands for damage
		}

	}
}