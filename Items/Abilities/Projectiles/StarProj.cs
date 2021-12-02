using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;
using ROTMG_Items.Dusts;

namespace ROTMG_Items.Items.Abilities.Projectiles
{
	public class StarProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 6;
		}
		public override string Texture => "ROTMG_Items/Items/Abilities/Projectiles/Star_Sheet";
		public override void SetDefaults()
		{
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
			projectile.frame = (int)projectile.ai[1];
			projectile.rotation = projectile.timeLeft * 2;
		}
	}
}