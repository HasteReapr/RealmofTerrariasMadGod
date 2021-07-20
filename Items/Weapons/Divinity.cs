using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.Items.Weapons
{
    public class Divinity : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinity"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("The chosen blade of Oryx the Mad God, charged with an unrelenting energy to subdue all that lies before it.\nIgnores the degense of enemies.");
        }

        public override void SetDefaults()
        {
            item.damage = 3500;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 5000000;
            item.rare = ItemRarityID.Expert;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Divinity_Beam>();
            item.shootSpeed = 16f;
        }
        public float timer = 120;
        public override void HoldItem(Player player)
        {
            base.HoldItem(player);
            player.armorPenetration = 2000000;
            timer--;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        { 
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            if (timer <= 0)
            {
                position = Main.MouseWorld;
                Projectile.NewProjectile(position.X, position.Y - 64, speedX, speedY, ModContent.ProjectileType<Holy_Beam>(), 6000, knockBack, player.whoAmI);
                timer = 120;
            }
            return false;
        }
    }
}