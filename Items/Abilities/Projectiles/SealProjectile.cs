using System;
using Terraria;
using Terraria.ModLoader;
using ROTMG_Items.Items.Abilities;
using Microsoft.Xna.Framework;
using ROTMG_Items.Buffs;

namespace ROTMG_Items.Items.Abilities.Projectiles
{
    class SealProjectile : ModProjectile
    {
        public override string Texture => "ROTMG_Items/Items/Abilities/Projectiles/SkullAOE";

        int[] time = {
            300,
            420,
            540,
            660,
            780,
            1560
        };

        int[] buff = {
            ModContent.BuffType<HPBoost>(),
            ModContent.BuffType<HPBoost2>(),
            ModContent.BuffType<HPBoost3>(),
            ModContent.BuffType<HPBoost4>(),
            ModContent.BuffType<HPBoost5>(),
            ModContent.BuffType<HPBoost6>()
        };
        public override void SetDefaults()
        {
            projectile.timeLeft = 5;
            projectile.height = (16 * 20);
            projectile.width = (16 * 20);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == target.team && target.team != 0)
                {
                    target.AddBuff(buff[(int)projectile.ai[1]], time[(int)projectile.ai[1]]);
                    target.AddBuff(ModContent.BuffType<Damaging>(), time[(int)projectile.ai[1]]);
                    if(projectile.ai[1] >= 1)
                    {
                        target.AddBuff(ModContent.BuffType<Healing>(), time[(int)projectile.ai[1]]);
                    }
                }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 80; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Dusts.HealDust>(), 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 1f;
            }
        }
    }
}
