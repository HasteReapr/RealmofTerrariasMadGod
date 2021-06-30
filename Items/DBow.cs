using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;

namespace ROTMG_Items.Items
{
	public class DBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doom Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("No mortal can fire this dreaded bow without resting in between shots. It requires tremendous skill to wield.");
		}

		public override void SetDefaults()
		{
			item.damage = 4500;
			item.ranged = true;
			item.noMelee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 90;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 3;
			item.value = 5000000;
			item.rare = ItemRarityID.Expert;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<DBow_Arrow>();
			item.shootSpeed = 32f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}