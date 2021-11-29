using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Placeable
{
	public class Sprite_Bit_Item : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cuboid Block");
			Tooltip.SetDefault("A block torn from the ground of the sprite world.");
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
			item.createTile = ModContent.TileType<Tiles.Sprite_Bit>();
			item.width = 12;
			item.height = 12;
			item.value = 3000;
		}
	}
}