using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class NecromaticEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necromatic Essence");
			Tooltip.SetDefault("An essence that reminats pure evil...");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.width = 12;
			item.height = 12;
			item.value = 3000;
		}

		public override void AddRecipes()
		{
			ModRecipe CorruptRecipe = new ModRecipe(mod);
			CorruptRecipe.AddIngredient(ItemID.Bone, 10);
			CorruptRecipe.AddIngredient(ItemID.RottenChunk, 5);
			CorruptRecipe.AddTile(TileID.WorkBenches);
			CorruptRecipe.SetResult(this);
			CorruptRecipe.AddRecipe();
			
			ModRecipe CrimsonRecipe = new ModRecipe(mod);
			CrimsonRecipe.AddIngredient(ItemID.Bone, 10);
			CrimsonRecipe.AddIngredient(ItemID.Vertebrae, 5);
			CrimsonRecipe.AddTile(TileID.WorkBenches);
			CrimsonRecipe.SetResult(this);
			CrimsonRecipe.AddRecipe();
		}
	}
}