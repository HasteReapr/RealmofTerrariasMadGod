using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items;
using ROTMG_Items;
using ROTMG_Items.Items.Materials;
using ROTMG_Items.Items.Abilities.Projectiles;

namespace ROTMG_Items.Items.Abilities
{
	public class t6Star : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doom Shuriken");
			Tooltip.SetDefault("A deadly shuriken infused with the power of the MoonLord.");
		}

		public override void SetDefaults()
		{
			item.damage = 980;
			AncientCost = 40;
			item.width = 40;
			item.height = 40;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = 1000000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<StarProj>();
			item.shootSpeed = 16f;
			isAbility = true;
			tier = 5;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
			return false;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<LunarEssence>());
			recipe.AddIngredient(ModContent.ItemType<t5Star>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}