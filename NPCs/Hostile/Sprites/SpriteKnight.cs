using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ROTMG_Items.NPCs.Projectiles;

namespace ROTMG_Items.NPCs.Hostile.Sprites
{
    class SpriteKnight : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sprite Knight");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.damage = 20;
            npc.width = 84;
            npc.height = 64;
            npc.lifeMax = 500;
        }

        private int AI_State_Slot = 0;
        private int wander = 0;
        private int attack = 1;
        private int randomdir = Main.rand.Next(2)+1;
        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }
        private int timer = 180;
        public override void AI()
        {
            npc.TargetClosest(true);
            Vector2 position = npc.Center;
            Vector2 targetpos = Main.player[npc.target].Center;
            Vector2 direction = targetpos - position;
            direction.Normalize();
            if(AI_State == wander)
            {
                timer--;
                if(npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) <= 1600)
                {
                    AI_State = attack;
                    timer = 60;
                }
                if (randomdir == 1)
                {
                    npc.direction = -1;
                    npc.velocity.X = 4;
                    if (timer <= 0)
                    {
                        AI_State = wander;
                        randomdir = Main.rand.Next(2) + 1;
                        timer = Main.rand.Next(240, 480);
                    }
                }
                else if (randomdir == 2)
                {
                    npc.direction = 1;
                    npc.velocity.X = -4;
                    if (timer <= 0)
                    {
                        randomdir = Main.rand.Next(2) + 1;
                        AI_State = wander;
                        timer = Main.rand.Next(240, 480);
                    }
                }
            }
            
            else if(AI_State == attack)
            {
                npc.velocity = new Vector2(0, 0);
                timer--;
                npc.direction *= -1;
                if(timer == 35)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Projectile.NewProjectile(npc.Center, direction * 16, ModContent.ProjectileType<Knight_Fire>(), 12, 1);
                    }
                }
                if(timer <= 0)
                {
                    timer = 60;
                }
            }
        }

        private int idle = 0;
        private int walk1 = 1;
        private int walk2 = 2;
        private int attack1 = 3;
        private int attack2 = 4;

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if(AI_State == wander)
            {
                if(npc.frameCounter <= 15)
                {
                    npc.frame.Y = walk1 * frameHeight;
                }
                else if(npc.frameCounter <= 30)
                {
                    npc.frame.Y = walk2 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }
            else if(AI_State == attack)
            {
                if(npc.frameCounter <= 30)
                {
                    npc.frame.Y = attack1 * frameHeight;
                }
                else if(npc.frameCounter <= 60)
                {
                    npc.frame.Y = attack2 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }
        }
    }
}
