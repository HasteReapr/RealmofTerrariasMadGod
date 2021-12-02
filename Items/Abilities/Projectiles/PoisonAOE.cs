using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ROTMG_Items.Items.Abilities.Projectiles
{
    class PoisonAOE : ModProjectile
    {
        public override string Texture => "ROTMG_Items/Items/Abilities/Projectiles/SkullAOE";

        public override void SetDefaults()
        {
            projectile.damage = 1;
            projectile.tileCollide = false;
            projectile.timeLeft = 4;
            projectile.height = 256;
            projectile.width = 256;
            projectile.penetrate = -1;
            projectile.friendly = true;
        }

        private int tier = 0;
        public override void AI()
        {
            if (projectile.ai[1] == 0)
            {
                tier = 1;
            }
            else if(projectile.ai[1] == 1)
            {
                tier = 2;
            }
            else if(projectile.ai[1] == 2)
            {
                tier = 3;
            }
            else if(projectile.ai[1] == 3)
            {
                tier = 4;
            }
            else if(projectile.ai[1] == 4)
            {
                tier = 5;
            }
            else if(projectile.ai[1] == 5)
            {
                tier = 6;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(tier == 1)
            {
                target.AddBuff(ModContent.BuffType<Buffs.t1Poison>(), 300);
            }
            else if(tier == 2)
            {
                target.AddBuff(ModContent.BuffType<Buffs.t1Poison>(), 400);
            }
            else if(tier == 3)
            {
                target.AddBuff(ModContent.BuffType<Buffs.t3Poison>(), 500);
            }
            else if(tier == 4)
            {
                target.AddBuff(ModContent.BuffType<Buffs.t3Poison>(), 600);
            }
            else if(tier == 5)
            {
                target.AddBuff(ModContent.BuffType<Buffs.t5Poison>(), 700);
            }
            else if(tier == 6)
            {
                target.AddBuff(ModContent.BuffType<Buffs.t6Poison>(), 1400);
            }
        }
    }
}
