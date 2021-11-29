using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Buffs //this is just a simple projectile that is supposed to be thrown by the testing potion the test buffs
    // or debuffs on enemies.
{
    class TestPotion_Thrown : ModProjectile
    {
        public override string Texture => "ROTMG_Items/Buffs/TestingPotion";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison bottle");
        }

        public override void SetDefaults()
        {
            projectile.damage = 1;
            projectile.penetrate = 1;
            projectile.timeLeft = 60;
            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = true;
        }
        private float rotate = 360;
        private float timer = 0;
        public override void AI()
        {
            timer--;
            if (timer <= 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.PoisonTrail>());
                timer = 3;
            }
            rotate -= 0.3f;
            projectile.rotation = rotate;
            if (projectile.timeLeft <= 30)
            {
                projectile.velocity.Y += 1f;
                if (projectile.velocity.Y >= 16)
                {
                    projectile.velocity.Y = 16;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Stunned>(), 300);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27, projectile.position);
        }
    }
}
