using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;

namespace ROTMG_Items.Items
{
	public class Ascended_Beam : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 45;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item1, projectile.position);
		}
	}
}