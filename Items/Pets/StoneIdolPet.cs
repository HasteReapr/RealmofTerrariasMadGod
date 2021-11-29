using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Pets
{
    public class StoneIdolPet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Idol");
            Main.projFrames[projectile.type] = 5;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 136;
            projectile.height = 136;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        private const int AI_State_Slot = 0;

        private const int idle = 0;
        private const int walk = 1;
        private const int fly = 2;
        public float AI_State
        {
            get => projectile.ai[AI_State_Slot];
            set => projectile.ai[AI_State_Slot] = value;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            PetPlayer modPlayer = player.GetModPlayer<PetPlayer>();
            Vector2 position = projectile.Center;
            Vector2 targetpos = player.Center;
            Vector2 direction = targetpos - position;
            if (!player.active)
            {
                projectile.active = false;
                return;
            }


            if (player.dead)
            {
                modPlayer.Stonepet = false;
            }


            if (modPlayer.Stonepet)
            {
                projectile.timeLeft = 2;
            }
            projectile.ai[1]++;

            if (player.Distance(projectile.Center) <= 80)
            {
                AI_State = idle;
            }
            

            if (player.Distance(projectile.Center) >= 240 && player.Distance(projectile.Center) <= 320)
            {
                AI_State = walk;
            }
            

            if (player.Distance(projectile.Center) >= 640)
            {
                AI_State = fly;
            }


            if (AI_State == idle)
            {
                projectile.tileCollide = true;
                projectile.velocity = new Vector2(0, 4);
                projectile.frame = 0;
            }
            else if (AI_State == walk)
            {
                projectile.tileCollide = true;
                projectile.velocity = new Vector2(direction.X * 0.03f, 4);
                if (++projectile.frameCounter >= 30)
                {
                    projectile.frameCounter = 0;
                    if (++projectile.frame >= 3)
                    {
                        projectile.frame = 1;
                    }
                }
            }
            else if (AI_State == fly)
            {
                projectile.tileCollide = false;
                projectile.velocity = direction * 0.05f;
                if (++projectile.frameCounter >= 15)
                {
                    projectile.frameCounter = 0;
                    if (++projectile.frame >= 5)
                    {
                        projectile.frame = 3;
                    }
                }
            }
        }
    }
}