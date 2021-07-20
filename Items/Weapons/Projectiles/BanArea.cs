using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Buffs;

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
