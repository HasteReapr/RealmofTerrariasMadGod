using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    class t1_Sword_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broadsword Swish");
        }

        public override void SetDefaults()
        {
            projectile.height = 14;
            projectile.width = 24;
            projectile.friendly = true;
            projectile.damage = 10;
            projectile.timeLeft = 25;
            projectile.penetrate = 1;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }
}
