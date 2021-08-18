using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using ROTMG_Items.NPCs.Projectiles;

namespace ROTMG_Items.NPCs.Bosses
{
    [AutoloadBossHead]
    class SpriteGoddess : ModNPC
    {
        public override string HeadTexture => "ROTMG_Items/NPCs/Bosses/SpriteGoddess_Head_Boss";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Limon the Sprite Goddess");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 7500;
            npc.height = 128;
            npc.width = 128;
            npc.damage = 40;
            npc.aiStyle = -1;
            npc.defense = 20;
            npc.knockBackResist = 1;
            npc.value = 10000;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.boss = true;
            music = MusicID.Boss1;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.69f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.75f);
        }

        private const int AI_State_Slot = 0;

        private int State_Choose = 0;
        private int State_Red = 1;
        private int State_Blue = 2;
        private int State_Green = 3;
        private int State_Teal = 4;
        private int State_Black = 5;
        private int State_Rage = 6;
        private int baby_rage = 7;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }
        private int timer = 180;
        private int shottimer = 30;
        private int phasechooser = Main.rand.Next(1, 6);
        private int randomdir = Main.rand.Next(1, 5);
        private int randomheight;
        private int heighttimer = 15;
        Vector2 bluepos;
        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }
            npc.TargetClosest(true);
            timer--;
            if (AI_State == State_Choose)
            {
                shottimer = 30;
                phasechooser = Main.rand.Next(1, 6);
                if (phasechooser == 1)
                {
                    AI_State = State_Red;
                    shottimer = 30;
                }
                else if (phasechooser == 2)
                {
                    AI_State = State_Blue;
                    shottimer = 0;
                }
                else if (phasechooser == 3)
                {
                    AI_State = State_Green;
                    npc.velocity = new Vector2(4, 4);
                    shottimer = 30;
                }
                else if (phasechooser == 4)
                {
                    shottimer = 60;
                    AI_State = State_Teal;
                    randomdir = Main.rand.Next(1, 4);
                }
                else if (phasechooser == 5)
                {
                    AI_State = State_Black;
                }
            }


            if (AI_State == State_Red)
            {
                Vector2 position = npc.Center;
                Vector2 targetPosition = Main.player[npc.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                Lighting.AddLight(npc.Center, Color.Red.ToVector3() * 6);
                npc.color = Color.Red;
                npc.velocity = direction * 6;
                shottimer--;
                if(shottimer <= 0)
                {
                    Projectile.NewProjectile(npc.Center, new Vector2(0,0), ModContent.ProjectileType<Sprite_Goddess_red_Proj>(), 20, 0, Main.myPlayer);
                    shottimer = 30;
                }
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                }
            }

            if (AI_State == State_Blue)
            { // goes to the left of the player and shoots a star of projectiles.
                bluepos = Main.player[npc.target].Center - new Vector2(320, randomheight);
                heighttimer--;
                if(heighttimer <= 0)
                {
                    randomheight = Main.rand.Next(32, 80) + 1;
                    heighttimer = 5;
                }
                Vector2 position = npc.Center;
                Vector2 targetPosition = Main.player[npc.target].Center;
                Vector2 direction = targetPosition - position;
                Vector2 directiontobluepos = bluepos - position;
                direction.Normalize();
                Lighting.AddLight(npc.Center, Color.Blue.ToVector3() * 6);
                npc.color = Color.Blue;
                if(npc.position != bluepos)
                {
                    npc.velocity = directiontobluepos;
                }
                else if(npc.position == bluepos)
                {
                    npc.position = bluepos;
                }
                shottimer--;
                if (shottimer <= 0)
                {
                    Projectile.NewProjectile(npc.Center - new Vector2(0, 100), direction * 6, ModContent.ProjectileType<Sprite_Goddess_blue_Proj>(), 15, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(0, 100), direction * 6, ModContent.ProjectileType<Sprite_Goddess_blue_Proj>(), 15, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center - new Vector2(100, 0), direction * 6, ModContent.ProjectileType<Sprite_Goddess_blue_Proj>(), 15, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(100, 0), direction * 6, ModContent.ProjectileType<Sprite_Goddess_blue_Proj>(), 15, 3, Main.myPlayer);
                    shottimer = 60;
                }
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                    heighttimer = 5;
                }
            }

            if (AI_State == State_Green)
            { // Goes in a circle and shoots green projectiles towards the player every .25 seconds.
                Vector2 position = npc.Center;
                Vector2 targetPosition = Main.player[npc.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                shottimer--;
                npc.velocity = npc.velocity.RotatedBy(MathHelper.Pi / 8 * Math.Sin(0.09f));
                Lighting.AddLight(npc.Center, Color.Green.ToVector3() * 6);
                npc.color = Color.Green;
                if(shottimer <= 0)
                {
                    Projectile.NewProjectile(npc.Center, direction * 6, ModContent.ProjectileType<Sprite_Goddess_green_Proj>(), 15, 3, Main.myPlayer);
                    shottimer = 15;
                }
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                }
            }

            if (AI_State == State_Teal)
            { // Goes in a random direction and shoots 8 projectiles.
                shottimer--;
                Lighting.AddLight(npc.Center, Color.Teal.ToVector3() * 6);
                npc.color = Color.Cyan;

                if(shottimer <= 0)
                {
                    Projectile.NewProjectile(npc.Center, new Vector2(0, 8), ModContent.ProjectileType<Sprite_Goddess_cyan_Proj>(), 20, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center, new Vector2(0, -8), ModContent.ProjectileType<Sprite_Goddess_cyan_Proj>(), 20, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center, new Vector2(8, 0), ModContent.ProjectileType<Sprite_Goddess_cyan_Proj>(), 20, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center, new Vector2(-8, 0), ModContent.ProjectileType<Sprite_Goddess_cyan_Proj>(), 20, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center, new Vector2(-8, 8), ModContent.ProjectileType<Sprite_Goddess_cyan_Proj>(), 20, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center, new Vector2(-8, -8), ModContent.ProjectileType<Sprite_Goddess_cyan_Proj>(), 20, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center, new Vector2(8, 8), ModContent.ProjectileType<Sprite_Goddess_cyan_Proj>(), 20, 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center, new Vector2(8, -8), ModContent.ProjectileType<Sprite_Goddess_cyan_Proj>(), 20, 3, Main.myPlayer);
                    shottimer = 60;
                }

                if(randomdir == 1)
                {
                    npc.velocity = new Vector2(4, -4);
                    if(timer <= 120)
                    {
                        npc.velocity = new Vector2(-4, 4);
                    }
                }
                else if(randomdir == 2)
                {
                    npc.velocity = new Vector2(-4, 4);
                    if(timer <= 120)
                    {
                        npc.velocity = new Vector2(4, -4);
                    }
                }
                else if(randomdir == 3)
                {
                    npc.velocity = new Vector2(4, 0);
                    if(timer <= 120)
                    {
                        npc.velocity = new Vector2(-4, 0);
                    }
                }
                else if(randomdir == 4)
                {
                    npc.velocity = new Vector2(-4, 0);
                    if(timer <= 120)
                    {
                        npc.velocity = new Vector2(4, 0);
                    }
                }
                if(timer <= 60)
                {
                    npc.velocity = new Vector2(0, 0);
                }
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                }
            }

            if (AI_State == State_Black)
            { //In this state, the NPC chases towards the player, that's all.
                Vector2 position = npc.Center;
                Vector2 targetPosition = Main.player[npc.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                Lighting.AddLight(npc.Center, Color.Black.ToVector3() * 6);
                npc.velocity = direction * 4;
                npc.color = Color.Gray;
                if (timer <= 0)
                {
                    AI_State = State_Choose;
                    timer = 180;
                }
            }

            if(Main.expertMode && npc.life <= npc.lifeMax * 0.1)
            {
                AI_State = State_Rage;
            }
            if(!Main.expertMode && npc.life <= npc.lifeMax * 0.1)
            {
                AI_State = baby_rage;
            }

            if(AI_State == baby_rage)
            { // The NPC charges the player a lot faster than gray and shoots 4 projectiles in the cardinel directions.
                shottimer--;
                npc.color = Color.Yellow;
                Vector2 position = npc.Center;
                Vector2 targetPosition = Main.player[npc.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                npc.velocity = direction * 8;
                if (shottimer <= 0)
                {
                    Projectile.NewProjectile(npc.Center + new Vector2(0, 64), new Vector2(0, 8), ModContent.ProjectileType<Sprite_Goddess_yellow_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(0, -64), new Vector2(0, -8), ModContent.ProjectileType<Sprite_Goddess_yellow_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(64, 0), new Vector2(8, 0), ModContent.ProjectileType<Sprite_Goddess_yellow_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(-64, 0), new Vector2(-8, 0), ModContent.ProjectileType<Sprite_Goddess_yellow_Proj>(), 20, 0, Main.myPlayer);
                    shottimer = 60;
                }
            }

            if(AI_State == State_Rage)
            { // Same as baby rage except diaganol directions too.
                shottimer--;
                npc.color = Color.Purple;
                Vector2 position = npc.Center;
                Vector2 targetPosition = Main.player[npc.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                npc.velocity = direction * 8;
                if(shottimer <= 0)
                {
                    Projectile.NewProjectile(npc.Center + new Vector2(0, 64), new Vector2(0, 8), ModContent.ProjectileType<Sprite_Goddess_purple_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(0, -64), new Vector2(0, -8), ModContent.ProjectileType<Sprite_Goddess_purple_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(64, 0), new Vector2(8, 0), ModContent.ProjectileType<Sprite_Goddess_purple_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(-64, 0), new Vector2(-8, 0), ModContent.ProjectileType<Sprite_Goddess_purple_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(-64, 64), new Vector2(-8, 8), ModContent.ProjectileType<Sprite_Goddess_purple_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(64, -64), new Vector2(-8, -8), ModContent.ProjectileType<Sprite_Goddess_purple_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(64, 64), new Vector2(8, 8), ModContent.ProjectileType<Sprite_Goddess_purple_Proj>(), 20, 0, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center + new Vector2(64, -64), new Vector2(8, -8), ModContent.ProjectileType<Sprite_Goddess_purple_Proj>(), 20, 0, Main.myPlayer);
                    shottimer = 30;
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
