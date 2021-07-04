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
	public class t3StarProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.frameCounter = 7;
			projectile.width = 34;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 60;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}

		public override void AI()
		{
			projectile.rotation = projectile.timeLeft * 2;
		}
	}
}