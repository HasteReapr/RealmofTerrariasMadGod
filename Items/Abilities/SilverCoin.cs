using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
	public class SilverCoin : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 4;
		}
		public override void SetDefaults()
		{
			projectile.width = 32;
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

			if (++projectile.frameCounter >= 15)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
		}

        public override void Kill(int timeLeft)
        {
			Main.PlaySound(SoundID.CoinPickup, projectile.position);
		}
    }
}