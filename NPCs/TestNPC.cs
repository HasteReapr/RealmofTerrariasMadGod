using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.NPCs
{
    class TestNPC : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knight of Oryx");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 128;
            npc.aiStyle = -1;
            npc.damage = 75;
            npc.defense = 20;
            npc.lifeMax = 2000;
            npc.knockBackResist = 0.5f;
            npc.value = 5000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.buffImmune[BuffID.OnFire] = true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.03f;
        }

        private const int AI_State_Slot = 0;

        private const int State_Wander = 0;
        private const int State_Spot = 1;
        private const int State_Lunge = 2;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }
        public float Timer = 250;
        public float wanderrand = Main.rand.Next(2) + 1;
        public float Jump_Cooldown;
        public override void AI()
        {
            Vector2 position = npc.Center;
            Vector2 targetPosition = Main.player[npc.target].Center;
            Vector2 direction = targetPosition - position;
            direction.Normalize();
            if (AI_State == State_Wander)
            {
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 160f)
                {
                    AI_State = State_Spot;
                    Timer = 180;
                }
                if (wanderrand == 1) {
                    npc.direction = 1;
                    if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 160f)
                    {
                        AI_State = State_Spot;
                        Timer = 180;
                    }else
                Timer--;
                npc.velocity.X = 1f;
                    if (Timer <= 10)
                    {
                        Timer = Main.rand.Next(250, 490);
                        wanderrand = Main.rand.Next(2) + 1;
                        AI_State = State_Wander;
                    }
                }


                if (wanderrand == 2) {
                npc.direction = -1;
                    if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 160f)
                    {
                        AI_State = State_Spot;
                        Timer = 180;
                    }else
                    Timer--;
                npc.velocity.X = -1f;
                    if (Timer <= 10)
                    {
                        wanderrand = Main.rand.Next(2) + 1;
                        Timer = Main.rand.Next(250, 490);
                        AI_State = State_Wander;
                    }
                   

                }


                else if (AI_State == State_Spot)
                {
                    Timer--;
                    npc.velocity.X = 0;
                    if (Timer == 150 && Main.player[npc.target].Distance(npc.Center) <= 160f)
                    {
                        AI_State = State_Lunge;
                        Timer = 30;
                    }
                    else if (Timer <= 100)
                    {
                        npc.TargetClosest(true);
                        if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) <= 500f)
                        {
                            AI_State = State_Wander;
                            Timer = 180;
                        }
                    }
                }
            }
            else if (AI_State == State_Lunge) {
                Timer--;
                npc.velocity = direction * 8f;
                if (Timer == 0)
                {
                    AI_State = State_Wander;
                    Timer = 180;
                }
            }
        } //NPC.downedPlantBoss

        private int KnightWalk_1 = 0;
        private int KnightWalk_2 = 1;
        private int KnightWalk_3 = 2;
        private int KnightWalk_4 = 3;

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            npc.spriteDirection = npc.direction;
            if (npc.frameCounter < 30)
            {
                npc.frame.Y = KnightWalk_1 * frameHeight;
            }
            else if (npc.frameCounter < 60)
            {
                npc.frame.Y = KnightWalk_2 * frameHeight;
            }
            else if (npc.frameCounter < 90)
            {
                npc.frame.Y = KnightWalk_3 * frameHeight;
            }
            else if (npc.frameCounter < 120)
            {
                npc.frame.Y = KnightWalk_4 * frameHeight;
            }
            else
            {
                npc.frameCounter = 0;
            }
        }
    }
}


