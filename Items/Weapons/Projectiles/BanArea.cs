using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Buffs;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    class BanArea : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 64;
            projectile.width = 64;
            projectile.friendly = true;
            projectile.timeLeft = 120;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }
        public override void AI()
        {
            if(projectile.timeLeft <= 80)
            {
                projectile.velocity *= 0.0002f;
            }
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = projectile.timeLeft;
            int dustToSpawn = 20;
            float radius = 3;
            float speed = 2;
            for (int i = 0; i < dustToSpawn; i++)
            {
                Vector2 dir = Vector2.UnitX.RotatedByRandom(MathHelper.Pi);
                Vector2 spawnPos = projectile.Center + dir * radius * 16;
                Vector2 spawnVel = dir * speed;
                Dust.NewDustPerfect(spawnPos, ModContent.DustType<Dusts.GhostlyDust>(), spawnVel);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<InstantDeath>(), 60000, false);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<InstantDeath>(), 60000, false);
        }
    }
}
