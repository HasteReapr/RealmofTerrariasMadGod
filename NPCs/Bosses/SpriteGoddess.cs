using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.NPCs.Bosses
{
    class SpriteGoddess : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Limon the Sprite Goddess");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 2000;
            npc.height = 128;
            npc.width = 128;
            npc.damage = 40;
            npc.aiStyle = -1;
            npc.defense = 20;
            npc.knockBackResist = 1;
            npc.value = 10000;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        private const int AI_State_Slot = 0;

        private int State_Choose = 0;
        private int State_Red = 1;
        private int State_Blue = 2;
        private int State_Green = 3;
        private int State_Teal = 4;
        private int State_Black = 5;


        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }
        private int timer = 180;
        private int phasechooser = Main.rand.Next(1,5) + 1;
        public override void AI()
        {
            npc.TargetClosest(true);
            timer--;
            if (AI_State == State_Choose)
            {
                Main.NewText("State Choose");
                phasechooser = Main.rand.Next(1, 5) + 1;
                if (phasechooser == 1)
                {
                    AI_State = State_Red;
                }
                else if (phasechooser == 2)
                {
                    AI_State = State_Blue;
                }
                else if (phasechooser == 3)
                {
                    AI_State = State_Green;
                }
                else if (phasechooser == 4)
                {
                    AI_State = State_Teal;
                }
                else if (phasechooser == 5)
                {
                    AI_State = State_Black;
                }
            }


            if (AI_State == State_Red)
            {
                Lighting.AddLight(npc.Center, Color.Red.ToVector3() * 2);
                Main.NewText("State Red");
                npc.color = Color.Red;
                npc.velocity = npc.velocity.RotatedBy(-MathHelper.Pi / 8);
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                }
            }

            if (AI_State == State_Blue)
            {
                Lighting.AddLight(npc.Center, Color.Blue.ToVector3() * 2);
                Main.NewText("State Blue");
                npc.color = Color.Blue;
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                }
            }

            if (AI_State == State_Green)
            {
                Lighting.AddLight(npc.Center, Color.Green.ToVector3() * 2);
                Main.NewText("State Green");
                npc.color = Color.Green;
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                }
            }

            if (AI_State == State_Teal)
            {
                Lighting.AddLight(npc.Center, Color.Teal.ToVector3() * 2);
                Main.NewText("State Teal");
                npc.color = Color.Teal;
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                }
            }

            if (AI_State == State_Black)
            {
                Vector2 position = npc.Center;
                Vector2 targetPosition = Main.player[npc.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                Lighting.AddLight(npc.Center, Color.Black.ToVector3() * 2);
                Main.NewText("State Black");
                npc.velocity = direction * 8;
                npc.color = Color.Gray;
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                }
            }
        }

        private const int Sprite_walk1 = 0;
        private const int Sprite_walk2 = 1;
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            npc.spriteDirection = npc.direction;
            if (npc.frameCounter < 30)
            {
                npc.frame.Y = Sprite_walk1 * frameHeight;
            }
            else if (npc.frameCounter < 60)
            {
                npc.frame.Y = Sprite_walk2 * frameHeight;
            }
            else
            {
                npc.frameCounter = 0;
            }
        }
    }
}
