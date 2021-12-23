using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    public class SquSpec : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 75;
            drawOffsetX = -22;
            drawOriginOffsetY = -6;
            drawOriginOffsetX = 9;
        }

        Vector2 mouse = Main.MouseWorld;
        bool foundTarget = false;
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.rotation = projectile.velocity.ToRotation();
            Vector2 targetCenter = new Vector2(0, 0);
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, projectile.Center);
                if (between < 2000f)
                {
                    targetCenter = npc.Center;
                    foundTarget = true;
                }
            }

            if (Main.LocalPlayer.whoAmI == projectile.owner)
            {
                if (projectile.timeLeft <= 50)
                {
                    if (!foundTarget)
                    {
                        projectile.velocity = projectile.DirectionTo(mouse) * 8;

                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            NPC npc = Main.npc[i];
                            if (npc.CanBeChasedBy())
                            {
                                float npcDistance = Vector2.Distance(npc.Center, projectile.Center);
                                bool closest = Vector2.Distance(projectile.Center, targetCenter) > npcDistance;

                                if (closest || !foundTarget)
                                {
                                    bool closeThroughWall = npcDistance < 100f;
                                    bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);

                                    if (lineOfSight || closeThroughWall)
                                    {
                                        targetCenter = npc.Center;
                                        foundTarget = true;
                                    }
                                }
                            }
                        }
                    }
                    else if (foundTarget)
                    {
                        projectile.velocity = projectile.DirectionTo(targetCenter) * 8;
                    }
                }
            }
        }
    }
}