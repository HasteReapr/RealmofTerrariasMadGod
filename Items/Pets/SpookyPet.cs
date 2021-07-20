using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Pets
{
	public class SpookyPet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scary Pet"); // Automatic from .lang files
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			projectile.width = 34;
			projectile.height = 34;
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			ROTMGPlayer modPlayer = player.GetModPlayer<ROTMGPlayer>();
			if (player.dead)
			{
				modPlayer.SpookyPet = false;
			}
			if (modPlayer.SpookyPet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}