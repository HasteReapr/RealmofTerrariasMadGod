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
	public class DBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dread Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A bow carried by the most fierce undead archers. It is tremendously powerful, but very large and awkward to use.\nTurns normal arrows into Dreadful Arrows.");
		}

		public override void SetDefaults()
		{
			item.damage = 300;
			item.ranged = true;
			item.noMelee = true;
			item.width = 48;
			item.height = 80;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.UseSound = SoundID.Item5;
			item.knockBack = 20;
			item.value = 100000;
			item.rare = ItemRarityID.Purple;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
				{
					type = ModContent.ProjectileType<DBow_Arrow>();
				}
			return true;
		}
	}
}