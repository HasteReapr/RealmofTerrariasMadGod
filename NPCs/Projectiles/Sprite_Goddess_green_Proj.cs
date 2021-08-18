using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.NPCs.Projectiles
{
    class Sprite_Goddess_green_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sprite Shuriken");
        }

        public override void SetDefaults()
        {
            projectile.knockBack = 0;
            projectile.width = 64;
            projectile.height = 64;
            projectile.damage = 40;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.timeLeft = 720;
            projectile.penetrate = 1;
        }

        private float rotatevalue;
        public override void AI()
        {
            rotatevalue -= 0.4f;
            projectile.rotation = rotatevalue;
        }
    }
}
