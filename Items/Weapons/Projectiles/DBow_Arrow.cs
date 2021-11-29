using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
	public class DBow_Arrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 72;
			projectile.height = 27;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 40;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
		}
	}
}