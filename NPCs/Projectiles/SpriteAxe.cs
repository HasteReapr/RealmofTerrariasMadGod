using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.NPCs.Projectiles
{
    class SpriteAxe : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sprite Axe");
        }
        public override void SetDefaults()
        {
            projectile.knockBack = 0;
            projectile.damage = 10;
            projectile.height = 90;
            projectile.width = 30;
            projectile.hostile = true;
            projectile.timeLeft = 600;
            projectile.penetrate = 1;
            projectile.tileCollide = false;
            projectile.aiStyle = 2;
        }
        private float rotation = 360;
        private bool zeroed = false;
        public override void AI()
        {
            rotation -= 0.09f;
            projectile.rotation = rotation;
            if (projectile.timeLeft <= 480)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.001f;
                if (projectile.velocity.Y > 16f)
                {
                    projectile.velocity.Y = 16f;
                }
            }
        }
    }
}
