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
            DisplayName.SetDefault("TestNPC");
        }

        public override void SetDefaults()
        {
            npc.width = 20;
            npc.height = 40;
            npc.aiStyle = -1;
            npc.damage = 15;
            npc.defense = 20;
            npc.lifeMax = 1500;
            npc.knockBackResist = 0.5f;
            npc.value = 50000;
            npc.HitSound = SoundID.NPCHit1; //I;m pretty sure this is zombie
            npc.DeathSound = SoundID.NPCDeath1; // I'm also pretty sure this is zombie
            npc.buffImmune[BuffID.OnFire] = true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.03f;
        }

        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;
        private const int AI_Jump_Wait = 2;
        private const int AI_Unused_Slot_3 = 3;

        private const int Local_AI_Unused_Slot_0 = 0;
        private const int Local_AI_Unused_Slot_1 = 1;
        private const int Local_AI_Unused_Slot_2 = 2;
        private const int Local_AI_Unused_Slot_3 = 3;

        private const int State_Wander = 0;
        private const int State_Spot = 1;
        private const int State_Lunge = 2;
        private const int State_Jump = 3;
        private const int State_Strike = 4;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }
        public float Timer = 180;
        public float wanderrand = Main.rand.Next(2) +1;
        public override void AI()
        {
            if (AI_State == State_Wander)
            {
                wanderrand = Main.rand.Next(2) + 1;
                if (wanderrand == 1) {
                    Timer--;
                    if (Timer <= 1)
                    {
                        npc.spriteDirection = 1;
                        npc.velocity.X = 0.5f;
                        Timer--;
                        if (Timer == 0)
                        {
                            Timer = 180;
                            AI_State = State_Wander;
                        }
                    }
                }
                if (wanderrand == 2) {
                    Timer--;
                    if (Timer <= 1)
                    {
                        npc.spriteDirection = -1;
                        npc.velocity.X = -0.5f;
                        Timer--;
                        if (Timer == 0)
                        {
                            Timer = 180;
                            AI_State = State_Wander;
                        }
                    }
                }
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 148f)
                {
                    AI_State = State_Spot;
                    Timer = 300;
                }
                else if (AI_State == State_Spot)
                {
                    if (Main.player[npc.target].Distance(npc.Center) < 128f)

                        npc.velocity.X *= 0;    
                        Timer--;
                        if (Timer == 150)
                        {
                            AI_State = State_Lunge;
                            Timer = 60;
                        }
                        else if (Timer <= 149)
                        {
                            npc.TargetClosest(true);
                            if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) > 500f)
                            {
                                // Our targeted player seems to have left our range, so we'll go back to wandering around.
                                AI_State = State_Wander;
                                Timer = 300;
                            }
                        }
                    }
                }
                else if (AI_State == State_Lunge){
                    Timer--;
                    npc.velocity *= 2f;
                    if(Timer <= 1)
                    {
                        Timer = 300;
                        AI_State = State_Wander;
                    }
                }
            } //NPC.downedPlantBoss
        }
    }

