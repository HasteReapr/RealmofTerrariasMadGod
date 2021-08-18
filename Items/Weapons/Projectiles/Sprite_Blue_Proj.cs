using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    class Sprite_Blue_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cubic Ice Shot");
        }
        public override void SetDefaults()
        {
            projectile.damage = 25;
            projectile.height = 32;
            projectile.width = 32;
            projectile.friendly = true;
            projectile.timeLeft = 240;
            projectile.penetrate = -1;
        }
        private float rotation = 360;
        public override void AI()
        {
            rotation -= 0.05f;
            projectile.rotation = rotation;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Slow, 180, false);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Slow, 180, false);
        }
    }
}
