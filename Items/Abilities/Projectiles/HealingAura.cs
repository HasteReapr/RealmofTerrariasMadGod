using System;
using Terraria;
using Terraria.ModLoader;
using ROTMG_Items.Items.Abilities;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Abilities.Projectiles
{
    class HealingAura : ModProjectile
    {
        public override string Texture => "ROTMG_Items/Items/Abilities/Projectiles/SkullAOE";

        int[] tiers = {
            25,
            50,
            100,
            125,
            150,
            250
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
                    Main.player[i].statLife += tiers[(int)projectile.ai[1]];
                }
        }
    }
}
