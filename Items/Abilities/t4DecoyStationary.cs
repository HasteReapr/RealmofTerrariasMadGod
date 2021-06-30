using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
	public class t4DecoyStationary : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.frameCounter = 7;
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.penetrate = 1000;
			projectile.timeLeft = 1680;
		}
		public override void AI()
		{
			Main.player[projectile.owner].tankPet = projectile.whoAmI;
			Main.player[projectile.owner].tankPetReset = false;
			projectile.velocity *= 0.001f;
			Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
			float distanceToCursor = vectorToCursor.Length();
			//Vector2.Distance(projectile.Center, cachedMousePosition) < 10f;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 50; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}
	}
}