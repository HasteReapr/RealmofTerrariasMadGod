using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Materials
{
	public class UnholyEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence of Unholy Power");
			Tooltip.SetDefault("An essence still writhing with the rage of demons.");
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