using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BeeDevSetBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purple Hoodie");
			Tooltip.SetDefault("It's warm and comfy!");
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
