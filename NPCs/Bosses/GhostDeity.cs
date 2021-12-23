using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using ROTMG_Items.NPCs.Projectiles;
using System;

namespace ROTMG_Items.NPCs.Bosses
{
    class GhostDeity : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ghost Deity");
            //Main.npcFrameCount[npc.type] = 4; set this to however many frames there are in total for all animations.
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 12000;
            npc.height = 128;
            npc.width = 128;
            npc.aiStyle = -1;
            npc.defense = 30;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.boss = true;
            music = MusicID.Boss2;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1.1f * bossLifeScale);
            npc.damage = (int)(npc.damage * 1.25f);
        }

        private const int AI_State_Slot = 0;
        private int FrameOne = 0;
        public bool Summon50 = false;
        public bool Summon25 = false;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            npc.TargetClosest(true);
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.alpha -= 10;
                    return;
                }
            }

            if (npc.life <= npc.lifeMax * 0.5f && !Summon50)
            {
                Summon50 = true;
                SummonMinions(false);
            }

            if (npc.life <= npc.lifeMax * 0.5f && !Summon25)
            {
                Summon25 = true;
                SummonMinions(false);
            }

            if (npc.life <= npc.lifeMax * 0.01f) // Add a rage trigger condition here.
            {
                SummonMinions(true); // When set to true here, it's saying that it is rage phase,
                                     // making the minions summoned more dangerous.
            }


        }

        private void RandomPhase()
        {
            Main.NewText("RandomPhase");
            int choosePhase = Main.rand.Next(2);
            if (choosePhase == 0)
            {
                BowPhase(30, 180);
            }
            else if (choosePhase == 1)
            {
                StaffPhase();
            }
        }

        private void BowPhase(int ShotTimer, int PhaseTimer)
        {
            Player player = Main.player[npc.target];
            Main.NewText("Bow Phase");
            // Change the sprite to the bow sprite, or use a seperate sprite sheet for it.
            // Aim at the player with a bow, shoot a line out that shows where the arrow is going to go, shoot the arrow at a velocity of 32
            Vector2 position = npc.Center;
            Vector2 targetPosition = Main.player[npc.target].Center;
            Vector2 direction = targetPosition - position;
            direction.Normalize();
            npc.TargetClosest(true);
            if (ShotTimer-- <= 0)
            {
                ShotTimer = 30;
                Projectile.NewProjectile(npc.Center, direction * 16, ModContent.ProjectileType<DreadArrow>(), 20, 0, Main.myPlayer);
            }
            RandomPhase();
        }

        private void StaffPhase()
        {
            Player player = Main.player[npc.target];
            Main.NewText("Staff Phase");
            // Change the sprite to the staff sprite, or use a seperate sprite sheet for it.
            // Staff shoots a tight shotgun of 3 at the player.
            // Make these projectiles ignore invuln frames.
        }

        private void SummonMinions(bool Rage)
        {
            Player player = Main.player[npc.target];
            Main.NewText("Summon Phase");
            // Change to a summoning sprite, where the deity raises it's arm and channels in some way, i.e. a ball being formed,
            // throw arm down and to whichever side, summon minions then.
            if (Rage)
            {

            }
            // Summon accursed skeletons, restless specters, and undead warriors.
            // Only do this at 50%, 25% and rage. Rage summoning enraged versions of the enemies, which attack faster and do more damage.

            if (!Rage)
            {
                int[] npcTypes =
                {
                    ModContent.NPCType<TestNPC>(),
                    ModContent.NPCType<Hostile.Sprites.SpriteKnight>(),
                    ModContent.NPCType<Hostile.Sprites.SpriteSpearer>(),
                    ModContent.NPCType<SpookyBoi>()
                };
                for (int x = 10; x > 0; x--)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, npcTypes[Main.rand.Next(4)]);
                }
            }
            // Enraged enemies will have a red outline to signify that they are different.
        }

        public override void FindFrame(int frameHeight)
        {
            // Draw code for the frames go here. Set the sprites/timing/amount in the phase method, it should animate automatically here.
        }
    }
}
