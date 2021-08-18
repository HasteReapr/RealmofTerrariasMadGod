using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    class Sprite_Green_Proj : ModProjectile
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
        }

        private float rotatevalue;
        public override void AI()
        {
            rotatevalue -= 0.4f;
            projectile.rotation = rotatevalue;

            if (projectile.timeLeft == 60)
            {
                projectile.velocity *= -1;
            }
        }
    }
}
