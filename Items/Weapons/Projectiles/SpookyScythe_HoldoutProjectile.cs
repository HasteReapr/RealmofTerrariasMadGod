using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
    public class SpookyScythe_HoldoutProjectile : ModProjectile
    {
        // This value controls how sluggish the Prism turns while being used. Vanilla Last Prism is 0.08f.
        // Higher values make the Prism turn faster.
        private const float AimResponsiveness = 0.2f;

        private int chargeDelay = 30;
        private int chargeLevel = -1;
        private int ShootDelay = 15;
        private bool fullCharge = false;
        private int colorRand = 0;
        private int[] projectiles = new int[6];
        private string[] colors = new string[6];

        private int[] projectileList =
        {
            ModContent.ProjectileType<Scythe_Projectiles>(), //armor break shot
            ModContent.ProjectileType<Scythe_Sick_Shot>(),
            ModContent.ProjectileType<Scythe_Slow_Shot>()
        };

        private string[] colorList =
        {
            "Red",
            "Green",
            "Blue"
        };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Scythe");
            // Signals to Terraria that this projectile requires a unique identifier beyond its index in the projectile array.
            // This prevents the issue with the vanilla Last Prism where the beams are invisible in multiplayer.
            ProjectileID.Sets.NeedsUUID[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.LastPrism);
            projectile.width = 120;
            projectile.height = 132;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);
            UpdatePlayerVisuals(player, rrp);
            if (projectile.owner == Main.myPlayer)
            {
                chargeDelay--;
                // Slightly re-aim the Prism every frame so that it gradually sweeps to point towards the mouse.
                UpdateAim(rrp, player.HeldItem.shootSpeed);

                // The Scythe immediately stops functioning if the player is Cursed (player.noItems) or "Crowd Controlled", e.g. the Frozen debuff.
                // player.channel indicates whether the player is still holding down the mouse button to use the item.
                bool stillInUse = player.channel && !player.noItems && !player.CCed && !fullCharge;

                if (stillInUse)
                {
                    ChargeShots();
                }

                // If the Scythe is no longer used, then destroy it immediately.
                else if (!stillInUse)
                {
                    if (chargeLevel > -1)
                    {
                        ShootShots();
                    }
                    else
                    {
                        projectile.Kill();
                    }
                }
            }

            projectile.timeLeft = 2;
        }

        private void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
        {
            projectile.Center = playerHandPos;

            // The beams emit from the tip of the Prism, not the side. As such, rotate the sprite by pi/2 (90 degrees).
            projectile.rotation += MathHelper.PiOver4 * projectile.spriteDirection;
            //projectile.spriteDirection = projectile.direction;

            // The Prism is a holdout projectile, so change the player's variables to reflect that.
            // Constantly resetting player.itemTime and player.itemAnimation prevents the player from switching items or doing anything else.
            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;

            player.itemRotation = (projectile.velocity * projectile.direction).ToRotation();
        }

        private void UpdateAim(Vector2 source, float speed)
        {
            Vector2 aim = Vector2.Normalize(Main.MouseWorld - source);
            if (aim.HasNaNs())
            {
                aim = -Vector2.UnitY;
            }

            // Change a portion of the Scythe's current velocity so that it points to the mouse. This gives smooth movement over time.
            aim = Vector2.Normalize(Vector2.Lerp(Vector2.Normalize(projectile.velocity), aim, AimResponsiveness));
            aim *= speed;

            if (aim != projectile.velocity)
            {
                projectile.netUpdate = true;
            }
            projectile.velocity = aim;
        }

        private void ChargeShots()
        {
            int uuid = Projectile.GetByUUID(projectile.owner, projectile.whoAmI);

            projectile.netUpdate = true;
            if (chargeDelay <= 0)
            {
                chargeLevel++;

                if (chargeLevel > -1)
                {
                    colorRand = Main.rand.Next(3);
                    projectiles[chargeLevel] = projectileList[colorRand];
                    colors[chargeLevel] = colorList[colorRand];
                }

                Main.PlaySound(SoundID.Item71, projectile.position);
                chargeDelay = 30;

                if (chargeLevel == 5)
                {
                    colorRand = Main.rand.Next(3);
                    projectiles[chargeLevel] = projectileList[colorRand];
                    colors[chargeLevel] = colorList[colorRand];
                    fullCharge = true;  //Setting the "full charge" here will make it happen ONLY after the final projectile gets charged
                }
            }
        }

        private void ShootShots()
        {
            int projectileType = projectiles[chargeLevel];
            if (ShootDelay-- <= 0)
            {
                Projectile.NewProjectile(projectile.Center, projectile.DirectionTo(Main.MouseWorld) * 16, projectileType, projectile.damage, projectile.knockBack, projectile.owner);
                ShootDelay = 5;
                Main.PlaySound(SoundID.Item38, projectile.position);
                chargeLevel--;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 sheetInsertPosition = (projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
            spriteBatch.Draw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)), Color.White, projectile.rotation, new Vector2(texture.Width / 2f, texture.Height / 2f), projectile.scale, effects, 0f);
            if(chargeLevel >= 0)
            {
                Texture2D zero = mod.GetTexture($"Items/Weapons/Projectiles/ScytheColors/SpookyScythe_{colors[0]}_1");
                spriteBatch.Draw(zero, sheetInsertPosition, new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)), Color.White, projectile.rotation, new Vector2(texture.Width / 2f, texture.Height / 2f), projectile.scale, effects, 0f);
            }
            if (chargeLevel >= 1)
            {
                Texture2D one = mod.GetTexture($"Items/Weapons/Projectiles/ScytheColors/SpookyScythe_{colors[1]}_2");
                spriteBatch.Draw(one, sheetInsertPosition, new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)), Color.White, projectile.rotation, new Vector2(texture.Width / 2f, texture.Height / 2f), projectile.scale, effects, 0f);
            }
            if (chargeLevel >= 2)
            {
                Texture2D two = mod.GetTexture($"Items/Weapons/Projectiles/ScytheColors/SpookyScythe_{colors[2]}_3");
                spriteBatch.Draw(two, sheetInsertPosition, new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)), Color.White, projectile.rotation, new Vector2(texture.Width / 2f, texture.Height / 2f), projectile.scale, effects, 0f);
            }
            if (chargeLevel >= 3)
            {
                Texture2D three = mod.GetTexture($"Items/Weapons/Projectiles/ScytheColors/SpookyScythe_{colors[3]}_4");
                spriteBatch.Draw(three, sheetInsertPosition, new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)), Color.White, projectile.rotation, new Vector2(texture.Width / 2f, texture.Height / 2f), projectile.scale, effects, 0f);
            }
            if (chargeLevel >= 4)
            {
                Texture2D four = mod.GetTexture($"Items/Weapons/Projectiles/ScytheColors/SpookyScythe_{colors[4]}_5");
                spriteBatch.Draw(four, sheetInsertPosition, new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)), Color.White, projectile.rotation, new Vector2(texture.Width / 2f, texture.Height / 2f), projectile.scale, effects, 0f);
            }
            if (chargeLevel >= 5)
            {
                Texture2D five = mod.GetTexture($"Items/Weapons/Projectiles/ScytheColors/SpookyScythe_{colors[5]}_6");
                spriteBatch.Draw(five, sheetInsertPosition, new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)), Color.White, projectile.rotation, new Vector2(texture.Width / 2f, texture.Height / 2f), projectile.scale, effects, 0f);
            }
            // add a new spriteBatch.Draw line 6 times, and do some fancy shit so it calls the color
            return false;
        }
    }
}