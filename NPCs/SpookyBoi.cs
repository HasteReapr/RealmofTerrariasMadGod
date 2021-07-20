using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace ROTMG_Items.NPCs
{
    class SpookyBoi : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lost Paladin");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 130;
            npc.height = 130;
            npc.aiStyle = -1;
            npc.damage = 999999999;
            npc.defense = 1000000;
            npc.lifeMax = 8000;
            npc.knockBackResist = 1;
            npc.value = 20000;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit49;
            npc.DeathSound = SoundID.NPCDeath49;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.WeaponImbuePoison] = true;
            npc.buffImmune[BuffID.WeaponImbueVenom] = true;
            npc.buffImmune[BuffID.WeaponImbueNanites] = true;
            npc.buffImmune[BuffID.WeaponImbueIchor] = true;
            npc.buffImmune[BuffID.WeaponImbueGold] = true;
            npc.buffImmune[BuffID.WeaponImbueFire] = true;
            npc.buffImmune[BuffID.WeaponImbueCursedFlames] = true;
            npc.buffImmune[BuffID.Weak] = true;
            npc.buffImmune[BuffID.Venom] = true;
            npc.buffImmune[BuffID.StardustMinionBleed] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
            npc.buffImmune[BuffID.Frostburn] = true;
            npc.buffImmune[BuffID.Confused] = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(spawnInfo.player.GetModPlayer<ROTMGPlayer>().Lost_Halls == true && spawnInfo.player.GetModPlayer<ROTMGPlayer>().moonded == false)
            {
                return 1f;
            }
            return 0f;
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Pets.SpookyCloth>(), 1);
        }
        
        private const int AI_State_Slot = 0;

        private const int State_Wander = 0; // these are mainly for the animation bit, because the validtarget range for the NPC is infinite.
        private const int State_Attack = 1;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }
        public float AttackType;
        public int attackcooldown = 15;

        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                attackcooldown--; //Attack cooldown, it's 30 so it attcks once every 0.5 seconds.
            }
            if (AI_State == State_Wander)
            {
                npc.TargetClosest(true);
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 1600f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    AI_State = State_Attack;
                }
            }
            
            if(AI_State == State_Attack)
            {
                Vector2 position = npc.Center;
                Vector2 targetPosition = Main.player[npc.target].Center;
                Vector2 direction = targetPosition - position;
                float speed = 16f;
                direction.Normalize();
                Vector2 side = new Vector2((float)Math.Cos(45) / speed, (float)Math.Sin(45) / speed); // to define a Vector2 like this, you need to start with the variable name, and then after the = put New Vector2. If you don't do this, it won't work.
                Vector2 side2 = new Vector2((float)Math.Cos(90) / speed, (float)Math.Sin(90) / speed);
                npc.velocity = direction * 6f;
                if(!npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 1600f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    AI_State = State_Wander;
                };
                if (attackcooldown == 0)
                {
                    int RandomAtt = Main.rand.Next(3) + 1; // chooses which attack to do, from lowest to highest damage.
                    if(RandomAtt == 1) 
                    {
                        int type = ModContent.ProjectileType<NPCs.Projectiles.Spooky_Sick_Shot>(); // it's called Sick_Shot but it doesn't apply a debuff, it's mainly because of the color and a reference to the actual game.
                        Projectile.NewProjectile(position, direction * speed, type, 75, 0f, Main.myPlayer);
                        Projectile.NewProjectile(position, (direction*-1) * speed, type, 75, 0f, Main.myPlayer); //forward and behind

                        Projectile.NewProjectile(position, (side * -1) * (speed * 16), type, 75, 0f, Main.myPlayer); // left
                        Projectile.NewProjectile(position, side * (speed * 16), type, 75, 0f, Main.myPlayer);

                        Projectile.NewProjectile(position, (side2 * -1) * (speed * 16), type, 75, 0f, Main.myPlayer); //right
                        Projectile.NewProjectile(position, side2 * (speed * 16), type, 75, 0f, Main.myPlayer);
                        attackcooldown = 30;
                        RandomAtt = Main.rand.Next(3) + 1;
                        if (!npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient) // this goes for all of these, it just checks if it doesn't have a valid target, and if it doesn't it switches to the idle animation as it floats off.
                        {
                            AI_State = State_Wander;
                        }
                    }                    
                    if(RandomAtt == 2) 
                    {
                        int type = ModContent.ProjectileType<NPCs.Projectiles.Spooky_Break_Shot>();
                        Projectile.NewProjectile(position, direction * speed, type, 100, 0f, Main.myPlayer);
                        Projectile.NewProjectile(position, (direction*-1) * speed, type, 100, 0f, Main.myPlayer); //forward and behind

                        Projectile.NewProjectile(position, (side*-1) * (speed * 16), type, 100, 0f, Main.myPlayer); //left
                        Projectile.NewProjectile(position, side * (speed * 16), type, 100, 0f, Main.myPlayer);

                        Projectile.NewProjectile(position, (side2 * -1) * (speed * 16), type, 100, 0f, Main.myPlayer); //right
                        Projectile.NewProjectile(position, side2 * (speed * 16), type, 100, 0f, Main.myPlayer);
                        attackcooldown = 30;
                        RandomAtt = Main.rand.Next(3) + 1;
                        if (!npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            AI_State = State_Wander;
                        }
                    }                    
                    if(RandomAtt == 3) 
                    {
                        int type = ModContent.ProjectileType<NPCs.Projectiles.Spooky_Slow_Shot>();
                        Projectile.NewProjectile(position, direction * speed, type, 175, 0f, Main.myPlayer);
                        Projectile.NewProjectile(position, (direction*-1) * speed, type, 175, 0f, Main.myPlayer);//forward and behind

                        Projectile.NewProjectile(position, (side * -1) * (speed * 16), type, 175, 0f, Main.myPlayer);//left
                        Projectile.NewProjectile(position, side * (speed * 16), type, 175, 0f, Main.myPlayer);

                        Projectile.NewProjectile(position, (side2 * -1) * (speed * 16), type, 175, 0f, Main.myPlayer);//right
                        Projectile.NewProjectile(position, side2 * (speed * 16), type, 175, 0f, Main.myPlayer);
                        attackcooldown = 30;
                        RandomAtt = Main.rand.Next(3) + 1;
                        if (!npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            AI_State = State_Wander;
                        }
                    }
                }
            }
        }
        private const int Spooky_Walk1 = 0;
        private const int Spooky_Walk2 = 1;
        private const int Spooky_Attack1 = 2;
        private const int Spooky_Attack2 = 3;

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            npc.spriteDirection = npc.direction;
            if(AI_State == State_Wander)
            {
                if (npc.frameCounter < 30)
                {
                    npc.frame.Y = Spooky_Walk1 * frameHeight;
                }            
                else if (npc.frameCounter < 60)
                {
                    npc.frame.Y = Spooky_Walk2 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }
            else if (AI_State == State_Attack)
            {
                if(npc.frameCounter < 30)
                {
                    npc.frame.Y = Spooky_Attack1 * frameHeight;
                }
                else if (npc.frameCounter < 60)
                {
                    npc.frame.Y = Spooky_Attack2 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }
        }
    }
}
