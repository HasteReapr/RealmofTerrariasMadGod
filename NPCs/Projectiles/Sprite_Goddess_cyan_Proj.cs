using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.NPCs.Projectiles
{
    class Sprite_Goddess_cyan_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sprite Boomerang");
        }

        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 64;
            projectile.damage = 40;
            projectile.tileCollide = true;
            projectile.hostile = true;
            projectile.timeLeft = 120;
        }

        private float rotatevalue;
        public override void AI()
        {
            rotatevalue -= 0.4f;
            projectile.rotation = rotatevalue;

            if(projectile.timeLeft == 60)
            {
                projectile.velocity *= -1;
            }
        }
    }
}
