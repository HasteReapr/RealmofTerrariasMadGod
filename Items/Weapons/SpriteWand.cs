using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using ROTMG_Items.Items.Weapons.Projectiles;
using ROTMG_Items.Items;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ROTMG_Items.Items.Weapons
{
    class SpriteWand : ModItem
    {
        public int frame;
        public int frameCounter;
        private int colortype = 1;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sprite Wand");
            Tooltip.SetDefault("A wand made by the sprite goddess herself, \n" +
                "it harnesses the power of all the elements.\n" +
                "Right click to change color of the wand!\n" +
                "Changing the color while change the projectile it shoots!");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(999999999, 5));
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 34;
            item.damage = 40;
            item.noUseGraphic = false;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item106;
            item.shoot = ModContent.ProjectileType<Sprite_Red_Proj>();
            item.shootSpeed = 16;
            item.autoReuse = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (colortype == 1)
            {
                item.autoReuse = false;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Sprite_Red_Proj>(), 40, 3, Main.myPlayer);
            }
            else if(colortype == 2)
            {
                item.autoReuse = true;
                item.shootSpeed = 8;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Sprite_Cyan_Proj>(), 40, 3, Main.myPlayer);
            }
            else if(colortype == 3)
            {
                item.autoReuse = true;
                item.shootSpeed = 6;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Sprite_Blue_Proj>(), 40, 3, Main.myPlayer);
            }
            else if(colortype == 4)
            {
                item.autoReuse = true;
                item.shootSpeed = 4;
                item.useTime = 5;
                item.useAnimation = 5;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Sprite_Green_Proj>(), 40, 3, Main.myPlayer);
            }
            else if(colortype == 5)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Sprite_Gray_Proj>(), 40, 3, Main.myPlayer);
            }
            return false;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.noUseGraphic = true;
                item.damage = 0;
                item.useTime = 30;
                item.useAnimation = 30;
                colortype += 1;
                if(colortype > 5)
                {
                    colortype = 1;
                }
            }
            return base.CanUseItem(player);
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frameI, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            // change to match your animated texture of choice
            Texture2D texture = ModContent.GetTexture("ROTMG_Items/Items/Weapons/SpriteWand");
            int timeFramesPerAnimationFrame = 9999999;
            int totalAnimationFrames = 5;
            if(colortype == 1)
            {
                frame = 0;
            }
            else if(colortype == 2)
            {
                frame = 1;
            }
            else if(colortype == 3)
            {
                frame = 2;
            }
            else if(colortype == 4)
            {
                frame = 3;
            }
            else if(colortype == 5)
            {
                frame = 4;
            }
            spriteBatch.Draw(texture, position, item.GetCurrentFrame(ref frame, ref frameCounter, timeFramesPerAnimationFrame, totalAnimationFrames), Color.White, 0f, origin, scale, SpriteEffects.None, 0);
            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            // use a held projectile for this instead of whatever the fuck this is
            int timeFramesPerAnimationFrame = 99999999;
            int totalAnimationFrames = 5;
            Texture2D texture = ModContent.GetTexture("ROTMG_Items/Items/Weapons/RedSpriteWand");
            if (colortype == 1)
            {
                texture = ModContent.GetTexture("ROTMG_Items/Items/Weapons/RedSpriteWand");
                spriteBatch.Draw(texture, item.position - Main.screenPosition, item.GetCurrentFrame(ref frame, ref frameCounter, timeFramesPerAnimationFrame, totalAnimationFrames), lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            }
            if (colortype == 2)
            {
                texture = ModContent.GetTexture("ROTMG_Items/Items/Weapons/CyanSpriteWand");
                spriteBatch.Draw(texture, item.position - Main.screenPosition, item.GetCurrentFrame(ref frame, ref frameCounter, timeFramesPerAnimationFrame, totalAnimationFrames), lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            }
            if (colortype == 3)
            {
                texture = ModContent.GetTexture("ROTMG_Items/Items/Weapons/BlueSpriteWand");
                spriteBatch.Draw(texture, item.position - Main.screenPosition, item.GetCurrentFrame(ref frame, ref frameCounter, timeFramesPerAnimationFrame, totalAnimationFrames), lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            }
            if (colortype == 4)
            {
                texture = ModContent.GetTexture("ROTMG_Items/Items/Weapons/GreenSpriteWand");
                spriteBatch.Draw(texture, item.position - Main.screenPosition, item.GetCurrentFrame(ref frame, ref frameCounter, timeFramesPerAnimationFrame, totalAnimationFrames), lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            }
            if (colortype == 5)
            {
                texture = ModContent.GetTexture("ROTMG_Items/Items/Weapons/GraySpriteWand");
                spriteBatch.Draw(texture, item.position - Main.screenPosition, item.GetCurrentFrame(ref frame, ref frameCounter, timeFramesPerAnimationFrame, totalAnimationFrames), lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            }
            return true;
        }
    }
}
