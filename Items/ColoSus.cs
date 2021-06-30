using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System.Threading;

namespace ROTMG_Items.Items
{
	public class ColoSus : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sword of the ColoSUS"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("FUNNY SUS!!!!");
		}

		public override void SetDefaults() 
		{
			item.damage = 3;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 1;
			item.useAnimation = 1;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 10000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<ColoSus_ShotUp>();
			item.shootSpeed = 16f;
		}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			float numberProjectiles = 1; // this maybe needs a fix
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 0))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<ColoSus_ShotDown>(), damage, knockBack, player.whoAmI);
			}
			return false; //makes sure it doesn't shoot the projectile again after this
        }
	}
}