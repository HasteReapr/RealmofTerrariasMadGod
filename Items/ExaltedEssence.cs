using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class ExaltedEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence of Exalted Power");
			Tooltip.SetDefault("An essence with the unrivaled power of the exalted god.");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.width = 12;
			item.height = 12;
			item.value = 3000;
		}
	}
}