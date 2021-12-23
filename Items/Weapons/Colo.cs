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
	public class Colo : ModItem
	{
		int posneg = 0;
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sword of the Colossus"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A sword with an impossibly sharp edge. It has been designed with holy magic to slash like no other blade.");
		}

		public override void SetDefaults() 
		{
			item.damage = 2200;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = 10000000;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Colo_Shot_Up>();
			item.shootSpeed = 5f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if(posneg == 0)
            {
				Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, ModContent.ProjectileType<Colo_Shot_Up>(), item.damage, item.knockBack, player.whoAmI, 0, 0);
				posneg = 1;
			}
			else if (posneg == 1)
			{
				Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, ModContent.ProjectileType<Colo_Shot_Down>(), item.damage, item.knockBack, player.whoAmI, 0, 0);
				posneg = 0;
			}
			//float numberProjectiles = 1; // still needs a fix
			//float rotation = MathHelper.ToRadians(180);
			//position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45;
			return false; //makes sure it doesn't shoot the projectile again after this

        }
	}
}