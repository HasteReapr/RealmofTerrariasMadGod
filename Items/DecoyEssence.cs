using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Placeable;

namespace ROTMG_Items.Items
{
	public class DecoyEssense : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Decoy Essense");
			ItemID.Sets.SortingPriorityMaterials[item.type] = 58;
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
	}
}