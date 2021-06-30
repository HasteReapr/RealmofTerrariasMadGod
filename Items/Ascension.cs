using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;

namespace ROTMG_Items.Items
{
	public class Ascension : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ascension"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The blade of the fallen Mad God, imbued with powers from cosmic beings unknown to mere mortals.");
		}

		public override void SetDefaults()
		{
			item.damage = 22500;
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
			item.shoot = ModContent.ProjectileType<Ascended_Beam>();
			item.shootSpeed = 64f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberprojectiles = 3;
			float rotation = MathHelper.ToRadians(8);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 8;
			for (int i = 0; i < numberprojectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberprojectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}