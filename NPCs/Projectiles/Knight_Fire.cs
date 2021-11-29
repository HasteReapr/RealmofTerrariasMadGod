using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.NPCs.Projectiles
{
    class Knight_Fire : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knight Flames");
        }

        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 24;
            projectile.hostile = true;
            projectile.timeLeft = 120;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            if(projectile.timeLeft <= 60)
            {
                projectile.velocity.X *= 0.9f;
                projectile.velocity.Y *= 1.3f;
                if(projectile.velocity.Y >= 16)
                {
                    projectile.velocity.Y = 16;
                }
            }
        }
    }
}
