using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Dusts;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Pets
{
	public class PatronPet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Supporter Extraordinaire Pet"); // Automatic from .lang files
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
		int timer = 30;
		int timer2 = 60;
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			PetPlayer modPlayer = player.GetModPlayer<PetPlayer>();
			if (player.dead)
			{
				modPlayer.SupporterPet = false;
			}
			if (modPlayer.SupporterPet)
			{
				projectile.timeLeft = 2;
			}

			int randomSize = Main.rand.Next(5);
			int randomPos = Main.rand.Next(34);
			int randomSize2 = Main.rand.Next(5);
			int randomPos2 = Main.rand.Next(34);
			if (timer-- <= 0)
            {
				Dust.NewDust(projectile.position + new Vector2(randomPos, randomPos), randomSize, randomSize, ModContent.DustType<RichDust>());
				timer = 30;
			}
			if(timer2-- <= 0)
            {
				Dust.NewDust(projectile.position + new Vector2(randomPos2, randomPos2), randomSize2, randomSize2, ModContent.DustType<RichDust>());
				timer2 = 60;
			}
			if (Main.rand.NextBool(10000))
            {
				Item.NewItem(projectile.position, ItemID.GoldCoin);
            }
		}
	}
}