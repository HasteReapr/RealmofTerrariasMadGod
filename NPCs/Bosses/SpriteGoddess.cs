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

        private int State_Choose = 1;
        private int State_Red = 2;
        private int State_Blue = 3;
        private int State_Green = 4;
        private int State_Teal = 5;
        private int State_Black = 6;
        private bool initialphase;


        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }
        private int testtimer = 180;
        private int phasechooser = Main.rand.Next(1,5) + 1;
        public override void AI()
        {
            if(initialphase == false)
            {
                AI_State = State_Choose;
                initialphase = true;
            }
            testtimer--;
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
                if(testtimer >= 0)
                {
                    AI_State = State_Choose;
                }
            }

            if (AI_State == State_Blue)
            {
                Lighting.AddLight(npc.Center, Color.Blue.ToVector3() * 2);
                Main.NewText("State Blue");
                npc.color = Color.Blue;
                if (testtimer >= 0)
                {
                    AI_State = State_Choose;
                }
            }

            if (AI_State == State_Green)
            {
                Lighting.AddLight(npc.Center, Color.Green.ToVector3() * 2);
                Main.NewText("State Green");
                npc.color = Color.Green;
                if (testtimer >= 0)
                {
                    AI_State = State_Choose;
                }
            }

            if (AI_State == State_Teal)
            {
                Lighting.AddLight(npc.Center, Color.Teal.ToVector3() * 2);
                Main.NewText("State Teal");
                npc.color = Color.Teal;
                if (testtimer >= 0)
                {
                    AI_State = State_Choose;
                }
            }

            if (AI_State == State_Black)
            {
                Lighting.AddLight(npc.Center, Color.Black.ToVector3() * 2);
                Main.NewText("State Black");
                npc.color = Color.Black;
                if (testtimer >= 0)
                {
                    AI_State = State_Choose;
                }
            }
        }

        private const int Sprite_walk1 = 0;
        private const int Sprite_walk2 = 1;

        private const int Sprite_walk1_red = 0;
        private const int Sprite_walk2_red = 1;

        private const int Sprite_walk1_blue = 0;
        private const int Sprite_walk2_blue = 1;

        private const int Sprite_walk1_green = 0;
        private const int Sprite_walk2_green = 1;

        private const int Sprite_walk1_teal = 0;
        private const int Sprite_walk2_teal = 1;

        private const int Sprite_walk1_black = 0;
        private const int Sprite_walk2_black = 1;
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
