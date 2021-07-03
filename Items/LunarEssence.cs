using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class LunarEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence of Lunar Power");
			Tooltip.SetDefault("An essence that is beaming with the power of the Moon Lord.");
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