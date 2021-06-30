using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Dusts;

namespace ROTMG_Items.Items.Abilities
{
	public class GhostlyExplosion : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 256;
			projectile.height = 256;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 4;
		}
		public override void AI()
		{
			projectile.velocity *= 0.01f;
		}
	}
}