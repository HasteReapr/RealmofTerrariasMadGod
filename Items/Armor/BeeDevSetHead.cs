using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BeeDevSetHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bunny Hat");
			Tooltip.SetDefault("A soft flippy ear bunny hat!");
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
