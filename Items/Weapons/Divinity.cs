using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using ROTMG_Items.Items.Weapons.Projectiles;
using ROTMG_Items.Items;
using Microsoft.Xna.Framework.Graphics;

namespace ROTMG_Items.Items.Weapons
{
    public class Divinity : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinity"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A sword of corrupted holy power. It's weld by Oryx the mad god\nIgnores the defense of enemies.");
            // Ticks per frame, frame count
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
            //ItemID.Sets.ItemIconPulse[item.type] = false;
            //ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.noMelee = true;
            item.noUseGraphic = false;
            item.damage = 3500;
            item.melee = true;
            item.width = 34;
            item.height = 36;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3;
            item.value = 5000000;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Divinity_Beam>();
            item.shootSpeed = 16f;
        }
        public float timer = 120;
        public int frame;
        public int frameCounter;
        public override void HoldItem(Player player)
        {
            player.armorPenetration = 2000000; // Do this to armor pierce.
            timer--;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Divinity_Beam>(), damage, knockBack, player.whoAmI);
            if (timer <= 0) // Once the timer ticks down shoot the divinity beam, offset by 64 pixels because the beam is 64 pixels high. So it doesn't spawn in the middle at the mouse.
            {
                position = Main.MouseWorld;
                Projectile.NewProjectile(position.X, position.Y - 64, speedX, speedY, ModContent.ProjectileType<Holy_Beam>(), 6000, knockBack, player.whoAmI);
                timer = 120;
            }
            return false;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frameI, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            // change to match your animated texture of choice
            Texture2D texture = ModContent.GetTexture("ROTMG_Items/Items/Weapons/DivinityAnim");
            int timeFramesPerAnimationFrame = 10;
            int totalAnimationFrames = 4;
            Vector2 subs = new Vector2(0, 10);

            spriteBatch.Draw(texture, position - subs, item.GetCurrentFrame(ref frame, ref frameCounter, timeFramesPerAnimationFrame, totalAnimationFrames), Color.White, 0f, origin, scale, SpriteEffects.None, 0);
            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            // change to match your animated texture of choice
            Texture2D texture = ModContent.GetTexture("ROTMG_Items/Items/Weapons/Divinity");
            int timeFramesPerAnimationFrame = 10;
            int totalAnimationFrames = 4;

            spriteBatch.Draw(texture, item.position - Main.screenPosition, item.GetCurrentFrame(ref frame, ref frameCounter, timeFramesPerAnimationFrame, totalAnimationFrames), lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            return false;
        }
    }
}