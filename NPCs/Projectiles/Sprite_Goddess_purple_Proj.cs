using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.NPCs.Projectiles
{
    class Sprite_Goddess_purple_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupted Sprite Dagger");
        }

        public override void SetDefaults()
        {
            projectile.damage = 20;
            projectile.knockBack = 0;
            projectile.width = 64;
            projectile.height = 32;
            projectile.timeLeft = 180;
            projectile.hostile = true;
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

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (player.active && !player.dead)
                {
                    float between = Vector2.Distance(player.Center, projectile.Center);
                    distanceFromTarget = between;
                    targetCenter = player.Center;
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
            target.AddBuff(ModContent.BuffType<Buffs.VoidSickness>(), 300, false);
        }
    }
}
