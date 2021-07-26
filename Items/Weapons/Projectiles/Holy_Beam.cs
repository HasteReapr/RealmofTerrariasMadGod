using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    class Holy_Beam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            projectile.Name = "Holy Beam";
            Main.projFrames[projectile.type] = 16;
        }

        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 128;
            projectile.tileCollide = false;
            projectile.ignoreWater = false;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
        }

        public override void AI()
        {
            // Lighting.AddLight(projectile.center, Color.colorname.ToVector3() * strength); where strength is how strong the lighting is.
            Lighting.AddLight(projectile.Center, Color.Yellow.ToVector3() * (projectile.frame/2));
            projectile.velocity *= 0.001f;
            if (++projectile.frameCounter >= 3.75f)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 16)
                {
                    projectile.Kill();
                }
            }
        }
    }
}
