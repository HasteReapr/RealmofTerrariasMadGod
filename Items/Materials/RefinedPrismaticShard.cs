using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Placeable;

namespace ROTMG_Items.Items.Materials
{
	public class RefinedPrismaticShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Prismatic Shard");
			Tooltip.SetDefault("It has a faint hum to it, you might be able to use it to craft something powerful.");
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.PrismaticShard>();
			item.width = 12;
			item.height = 12;
			item.value = 3000;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Prismatic_Shard>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}