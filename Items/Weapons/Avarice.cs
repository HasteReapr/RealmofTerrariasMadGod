using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System.Threading;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.Items.Weapons
{
	public class Avarice : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avarice"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The pride of Treasurer Gemsbok, this gilded knife has backstabbed countless traders in shady dealings.");
		}
		int posneg = 0;

		public override void SetDefaults()
		{
			item.damage = 1300;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = 10000000;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<AvariceProjUp>();
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (posneg == 0)
			{
				Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, ModContent.ProjectileType<AvariceProjUp>(), item.damage, item.knockBack, player.whoAmI, 0, 0);
				posneg = 1;
			}
			else if (posneg == 1)
			{
				Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, ModContent.ProjectileType<AvariceProjDown>(), item.damage, item.knockBack, player.whoAmI, 0, 0);
				posneg = 0;
			}
			return false;

		}
	}
}