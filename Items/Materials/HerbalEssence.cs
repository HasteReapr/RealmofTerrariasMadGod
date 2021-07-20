using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Materials
{
	public class HerbalEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence of Herbal Power");
			Tooltip.SetDefault("An essence that's warm from Plantera's rage.");
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