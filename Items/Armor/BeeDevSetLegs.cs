using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BeeDevSetLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ripped Leggings");
			Tooltip.SetDefault("A pair of soft pants with some tears.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Purple;
			item.defense = 75;
		}
	}
}
