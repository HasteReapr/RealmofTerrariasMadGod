using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using ROTMG_Items.Buffs;

namespace ROTMG_Items.Items.Abilities.Projectiles
{
    class Ogmur_Proj : ModProjectile
    {
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 24;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 120;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(ModContent.BuffType<ArmorShattered>(), 720);
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
			target.AddBuff(ModContent.BuffType<ArmorShattered>(), 360);
        }
    }
}
