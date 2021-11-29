using System;
using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.NPCs.Projectiles
{
    class SpriteStab : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sprite Stab");
        }

        public override void SetDefaults()
        {
            projectile.height = 64;
            projectile.width = 64;
            projectile.hostile = true;
            projectile.timeLeft = 30;
        }

        public override void AI()
        {
            projectile.velocity *= 0.000001f;
        }
    }
}
