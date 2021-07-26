using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Abilities
{
	public class SilverCoin : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 32;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
		}

        public float Timer = 60;
		public float StartTimer = 60;
		public override void AI()
		{
			Main.player[projectile.owner].tankPet = projectile.whoAmI;
			Main.player[projectile.owner].tankPetReset = false;
			projectile.velocity *= 0.01f;
			if (projectile.ai[1] == 0)
			{
				StartTimer--;
				if (StartTimer == 0)
				{
					projectile.ai[1] = Main.rand.Next(2) + 1;
				}
			}
			if (projectile.ai[1] == 1)
			{
				Timer--;
				if (Timer == 0)
				{
					projectile.ai[1] = 3;
					Timer = 60;
				}
			}
			if (projectile.ai[1] == 2)
			{
				projectile.Kill();
			}
			if (projectile.ai[1] == 3)
			{
				projectile.ai[1] = Main.rand.Next(2) + 1;
			}

			if (++projectile.frameCounter >= 10)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
				{
					projectile.frame = 0;
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item1, projectile.position);
		}
	}
}