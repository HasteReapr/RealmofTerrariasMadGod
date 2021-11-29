using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Abilities
{
    class t2PoisonBottle : ModProjectile
    {
        public override string Texture => "ROTMG_Items/Items/Abilities/t2Poison";
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
            target.AddBuff(ModContent.BuffType<Buffs.t1Poison>(), 400);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, ModContent.ProjectileType<PoisonAOE>(), projectile.damage, 0, projectile.owner, 0, 1);
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.t2PoisonDust>(), 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27, projectile.position);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, ModContent.ProjectileType<PoisonAOE>(), projectile.damage, 0, projectile.owner, 0, 1);
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.t2PoisonDust>(), 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
            }
        }
    }
}
