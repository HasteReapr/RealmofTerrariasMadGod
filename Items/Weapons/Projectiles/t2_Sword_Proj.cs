using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    class t2_Sword_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Saber Swish");
        }

        public override void SetDefaults()
        {
            projectile.height = 14;
            projectile.width = 24;
            projectile.friendly = true;
            projectile.damage = 20;
            projectile.timeLeft = 15;
            projectile.penetrate = 1;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }
}
