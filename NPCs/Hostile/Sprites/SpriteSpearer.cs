using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ROTMG_Items.NPCs.Projectiles;

namespace ROTMG_Items.NPCs.Hostile.Sprites
{
    class SpriteSpearer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sprite Spearman");
            Main.npcFrameCount[npc.type] = 7;
        }
        public override void SetDefaults()
        {
            npc.damage = 10;
            npc.lifeMax = 40;
            npc.height = 64; //90
            npc.width = 64; //90
        }

        private const int AI_State_Slot = 0;

        private int wander = 0;
        private int attack = 1;
        private int throwaxe = 2;
        private int choose = 3;
        private int flee = 4;
        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }

        private int timer = 180;
        private int throwchance = 1;
        private int randdir;
        private bool axethrown = false;
        public override void AI()
        {
            npc.TargetClosest(true);
            Vector2 position = npc.Center;
            Vector2 targetpos = Main.player[npc.target].Center;
            Vector2 direction = targetpos - position;
            direction.Normalize();
            if (axethrown == true && AI_State != flee)
            {
                AI_State = flee;
            }
            if (AI_State == choose)
            {
                randdir = Main.rand.Next(1, 2) + 1;
                AI_State = wander;
            }
            else if (AI_State == wander)
            {
                if (timer >= 10 && npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) <= 128 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    AI_State = attack;
                    timer = 0;
                }
                randdir = Main.rand.Next(1, 2);
                if (randdir == 1 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    timer++;
                    npc.direction = -1;
                    npc.velocity.X = 1;
                    if (timer >= 180)
                    {
                        AI_State = choose;
                        timer = 0;
                    }
                }
                else if (randdir == 2 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    timer++;
                    npc.direction = 1;
                    npc.velocity.X = -1;
                    if (timer >= 180)
                    {
                        AI_State = choose;
                        timer = 0;
                    }
                }
            }
            else if (AI_State == attack)
            {
                npc.direction *= -1;
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) >= 128 && Main.player[npc.target].Distance(npc.Center) <= 360 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    AI_State = throwaxe;
                    timer = 0;
                }
                timer++;
                if (timer == 60)
                {
                    Projectile.NewProjectile(npc.Center - (new Vector2(64, 0)* npc.direction), new Vector2(0, 0), ModContent.ProjectileType<SpriteStab>(), 10, 3);
                }
                else if (timer >= 60 && timer <= 120)
                {
                }
                else if (timer >= 120)
                {
                    timer = 0;
                }
            }
            else if (AI_State == throwaxe)
            {
                timer++;
                if (timer >= 30 && axethrown == false)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Projectile.NewProjectile(position, direction * 16, ModContent.ProjectileType<SpriteAxe>(), 10, 3);
                    }
                    axethrown = true;
                }
                else if (timer >= 90 && axethrown == true)
                {
                    AI_State = flee;
                }
            }
            else if (AI_State == flee)
            {
                int dustToSpawn = 10;
                float radius = 5;
                float speed = 4;
                for (int i = 0; i < dustToSpawn; i++)
                {
                    Vector2 dir = Vector2.UnitX.RotatedByRandom(MathHelper.Pi);
                    Vector2 spawnPos = npc.Center + dir * radius * 16;
                    Vector2 spawnVel = dir * speed;
                    Dust.NewDustPerfect(spawnPos, ModContent.DustType<Dusts.ScepterDust>(), spawnVel);
                }
                npc.velocity = direction * new Vector2(-2, 0);
            }
        }

        private const int frame_still = 0;
        private const int frame_walk1 = 1;
        private const int frame_walk2 = 2;
        private const int frame_attack1 = 3;
        private const int frame_attack2 = 4;
        private const int frame_run = 5;
        private const int frame_run2 = 6;

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (AI_State == wander)
            {
                if (npc.frameCounter <= 30)
                {
                    npc.frame.Y = frame_walk1 * frameHeight;
                }
                else if (npc.frameCounter <= 60 && npc.frameCounter >= 30)
                {
                    npc.frame.Y = frame_walk2 * frameHeight;
                }
                else if (npc.frameCounter >= 60)
                {
                    npc.frameCounter = 0;
                }
            }
            if (AI_State == attack)
            {
                if (timer >= 60 && timer <= 90)
                {
                    npc.frame.Y = frame_attack2 * frameHeight;
                }
                else if (timer >= 90 && timer <= 120)
                {
                    npc.frame.Y = frame_attack1 * frameHeight;
                }
                else if (timer >= 120)
                {
                    npc.frameCounter = 0;
                }
            }
            if (axethrown == true)
            {
                if (npc.frameCounter <= 30)
                {
                    npc.frame.Y = frame_run * frameHeight;
                }
                else if (npc.frameCounter <= 60 && npc.frameCounter >= 30)
                {
                    npc.frame.Y = frame_run2 * frameHeight;
                }
                else if (npc.frameCounter >= 60)
                {
                    npc.frameCounter = 0;
                }
            }
        }
    }
}
