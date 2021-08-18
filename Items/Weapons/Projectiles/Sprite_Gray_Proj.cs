using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    class Sprite_Gray_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
			Main.projFrames[projectile.type] = 4;
		}
        public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 24;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 120;
			projectile.penetrate = 1;
			projectile.tileCollide = false;
		}
		public override void AI()
		{
			if (++projectile.frameCounter >= 15)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}

			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && projectile.Distance(Main.npc[k].Center) < 300f)
				{
					projectile.velocity = Vector2.Normalize(Main.npc[k].Center - projectile.Center) * 16f;
				}
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//private List<NPC> npcs = null; //figure out how to use lists, eventually.
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && projectile.Distance(Main.npc[k].Center) < 300f)
				{
					projectile.velocity = Vector2.Normalize(Main.npc[k].Center - projectile.Center) * 160f;
				}
			}
		}
	}
}
