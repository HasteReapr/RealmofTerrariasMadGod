using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    class Sprite_Red_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cubic Flame Shot");
        }

        public override void SetDefaults()
        {
            projectile.damage = 20;
            projectile.width = 32;
            projectile.height = 32;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            projectile.velocity = new Vector2(0, 0);
            Vector2 targetCenter = projectile.Center;
            bool foundTarget = false;
            float speed = 16f;
            float distanceFromTarget = 9999999f;

			for (int k = 0; k < 200; k++)
			{
                NPC npc = Main.npc[k];
                if (Main.npc[k].active && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && projectile.Distance(Main.npc[k].Center) < 9999)
				{
                    float between = Vector2.Distance(npc.Center, projectile.Center);
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                    if (foundTarget)
                    {
                        projectile.rotation = projectile.DirectionTo(targetCenter).ToRotation();
                    }
                }
			}
            Vector2 direction = targetCenter - projectile.Center;
            direction.Normalize();
            direction *= speed;
            if (projectile.timeLeft <= 120)
            {
                projectile.velocity = new Vector2(0, 0);
                if (foundTarget)
                {
                    projectile.rotation = projectile.DirectionTo(targetCenter).ToRotation();
                }
            }

            if (projectile.timeLeft <= 90)
            {
                projectile.velocity = direction;
            }

            if (projectile.timeLeft <= 30)
            {
                projectile.velocity *= 0.01f;
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 120, false);
        }
    }
}
