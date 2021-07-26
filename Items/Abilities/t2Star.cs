using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items;
using ROTMG_Items;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
	public class t2Star : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiral Shuriken");
			Tooltip.SetDefault("A complex shuriken design that is designed spin fast.");
		}

		public override void SetDefaults()
		{
			item.damage = 80;
			AncientCost = 30;
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
			item.shoot = ModContent.ProjectileType<t2StarProj>();
			item.shootSpeed = 16f;
			isAbility = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<GreaterEssence>());
			recipe.AddIngredient(ModContent.ItemType<t1Star>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}