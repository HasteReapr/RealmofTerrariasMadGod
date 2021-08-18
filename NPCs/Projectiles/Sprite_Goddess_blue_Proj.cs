using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.NPCs.Projectiles
{
    class Sprite_Goddess_blue_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cubic Ice Shot");
        }
        public override void SetDefaults()
        {
            projectile.knockBack = 0;
            projectile.damage = 25;
            projectile.height = 64;
            projectile.width = 64;
            projectile.hostile = true;
            projectile.timeLeft = 1000;
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
            target.AddBuff(BuffID.Slow, 60, false);
        }
    }
}
