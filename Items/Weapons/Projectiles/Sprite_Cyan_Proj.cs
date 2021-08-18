using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    class Sprite_Cyan_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sprite Boomerang");
        }

        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.damage = 40;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.timeLeft = 120;
            projectile.penetrate = 1;
        }

        private float rotatevalue;
        public override void AI()
        {
            rotatevalue -= 0.4f;
            projectile.rotation = rotatevalue;

            if (projectile.timeLeft == 60)
            {
                projectile.penetrate = -1;
                projectile.velocity *= -1;
            }
        }
    }
}
